using System;
using Interfaces;
using ObjectLoaderModule;
using UnityEngine;
using UnityEngine.Events;

namespace LevelModule
{
    public class PlantsSpawnManager : MonoBehaviour
    {
        public UnityEvent CompleteActionEvent;
        public event Action<int> SpawnPlantEvent;

        [SerializeField] private Transform _parentToSpawnTransform;

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
                if(Input.GetMouseButton(0))
                {
                    ThrowRay();
                }
                if (Input.GetMouseButtonUp(0))
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
            }
        }

        private void ThrowRay()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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

            var plantSO = ObjectLoader.LoadPlantSO(_selectedPlantType);
            var plant = Instantiate(plantSO.Prefab, _parentToSpawnTransform);
            plant.Initialize(plantSO.HealthPoints);
            plant.DestroyEvent += OnPlantDestroy;
            cell.SetPlant(plant);
            
            SpawnPlantEvent?.Invoke(plantSO.Price);
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

        private void OnPlantDestroy(IDestroyable plant)
        {
            Destroy((plant as Plant)?.gameObject);
        }
    }
}