using System;
using LevelModule.CharactersModule;
using UnityEngine;
using UnityEngine.Events;

namespace LevelModule
{
    public class PlantsSpawnManager : MonoBehaviour
    {
        public UnityEvent CompleteActionEvent;
        public event Action<int> SpawnPlantEvent;

        [SerializeField] private PlantsSpawner _plantsSpawner;

        private PlantType _selectedPlantType;
        private Cell _selectedCell;

        private bool _isPlantRemoving = false;
        
        public void SelectPlantType(PlantType newPlantType)
        {
            if (_isPlantRemoving)
            {
                _isPlantRemoving = false;
            }
            _selectedPlantType = _selectedPlantType == newPlantType ? PlantType.None : newPlantType;
        }

        public void PlantRemovingSwitch()
        {
            _selectedPlantType = PlantType.None;
            _isPlantRemoving = !_isPlantRemoving;
        }

        private void Update()
        {
            if(_selectedPlantType != PlantType.None || _isPlantRemoving)
            {
#if UNITY_STANDALONE || UNITY_EDITOR
                if(Input.GetMouseButton(0))
                {
                    ThrowRay(Input.mousePosition);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    HandleTouchEnd();
                }
#elif UNITY_ANDROID || UNITY_IOS
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        ThrowRay(touch.position);
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        HandleTouchEnd();
                    }
                }
#endif
            }
        }

        private void ThrowRay(Vector2 clickPosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(clickPosition);
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.TryGetComponent<Cell>(out var cell))
                {
                    if (_selectedCell != null && !cell.IsActive)
                    {
                        _selectedCell.Deactivate();
                    }
                    _selectedCell = cell;
                    _selectedCell.Activate();

                    return;
                }
            }
            
            _selectedCell?.Deactivate();
            _selectedCell = null;
        }

        private void HandleTouchEnd()
        {
            if(_selectedCell == null)
            {
                return;
            }
            _selectedCell.Deactivate();
                    
            if (_isPlantRemoving)
            {
                ClearCell(_selectedCell);
                return;
            }
            Spawn(_selectedCell);
        }

        private void Spawn(Cell cell)
        {
            if(_selectedCell == null || _selectedPlantType == PlantType.None)
            {
                Debug.LogError($"INVALID DATA\nSelected cell: {_selectedCell}\nSelected plant type: {_selectedPlantType}");
            }
            if (cell.IsBusy)
            {
                return;
            }

            _plantsSpawner.Spawn(cell, _selectedPlantType, out int price);
            SpawnPlantEvent?.Invoke(price);
            CompleteActionEvent?.Invoke();
            ResetData();
        }

        private void ClearCell(Cell cell)
        {
            cell.ClearCell();
            ResetData();
            CompleteActionEvent?.Invoke();
        }

        private void ResetData()
        {
            _selectedCell = null;
            _isPlantRemoving = false;
            _selectedPlantType = PlantType.None;
        }
    }
}