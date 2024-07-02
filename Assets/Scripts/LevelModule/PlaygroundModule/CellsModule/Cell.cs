using UnityEngine;

namespace LevelModule
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _activeMaterial;

        private Material _standartMaterial;
        private Plant _plantOnCell;

        public bool IsBusy => _plantOnCell != null;
        public bool IsActive { get; private set; }

        private void Awake()
        {
            _standartMaterial = _renderer.material;
        }

        public bool SetPlant(Plant spawnedPlant)
        {
            if(_plantOnCell != null)
            {
                return false;
            }

            _plantOnCell = spawnedPlant;
            _plantOnCell.gameObject.transform.position = _spawnTransform.position;
            return true;
        }

        public void ClearCell()
        {
            if (_plantOnCell == null)
            {
                return;
            }
            Destroy(_plantOnCell.gameObject);
            _plantOnCell = null;
        }

        public void Activate()
        {
            if (IsActive)
            {
                return;
            }

            _renderer.material = _activeMaterial;
            IsActive = true;
        }

        public void Deactivate()
        {
            _renderer.material = _standartMaterial;
            IsActive = false;
        }
    }
}