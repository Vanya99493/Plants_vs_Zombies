using Interfaces;
using ObjectLoaderModule;
using PlantsModule;
using PlaygroundModule.CellsModule;
using UnityEngine;

namespace PlaygroundModule
{
    public class PlantsSpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform _parentToSpawnTransform;

        private PlantType _selectedPlantType;
        private Cell _selectedCell;

        public void SelectPlantType(PlantType newPlantType)
        {
            _selectedPlantType = _selectedPlantType == newPlantType ? PlantType.None : newPlantType;
        }

        private void Update()
        {
            if(_selectedPlantType != PlantType.None)
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

            var plantSO = ObjectLoader.LoadPlantSO(_selectedPlantType);
            var plant = Instantiate(plantSO.Prefab, _parentToSpawnTransform);
            plant.Initialize(plantSO.HealthPoints);
            plant.DestroyEvent += OnPlantDestroy;

            _selectedCell = null;

            if (!cell.SetPlant(plant))
            {
                Destroy(plant.gameObject);
            }
        }

        private void OnPlantDestroy(IDestroyable plant)
        {
            Destroy((plant as Plant)?.gameObject);
        }
    }
}