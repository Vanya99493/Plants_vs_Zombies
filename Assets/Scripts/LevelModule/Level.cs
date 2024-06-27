using Infrastructure;
using ObjectLoaderModule;
using PlaygroundModule;
using UIModule;
using UnityEngine;

namespace LevelModule
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private LevelDifficultyType _levelDifficultyType;
        [SerializeField] private DIContainer _diContainer;
        [SerializeField] private UIController _uiController;
        [SerializeField] private PlantsSpawnManager _plantsSpawnManager;
        [SerializeField] private ZombiesSpawner _zombiesSpawner;

        private WavesController _wavesController;

        private void Awake()
        {
            if (_diContainer != null)
            {
                _diContainer.Initialize();
            }
            
            InitializeGameHud();
            StartLevel();
        }
        
        private void StartLevel()
        {
            _wavesController = new WavesController(_zombiesSpawner);
            LevelSO levelSO = ObjectLoader.LoadLevelSO(_levelDifficultyType);
            _wavesController.StartSpawnZombies(levelSO);
        }

        private void InitializeGameHud()
        {
            _uiController.InitializeGameHud(_plantsSpawnManager.SelectPlantType, 
                _plantsSpawnManager.SelectPlantType, 
                _plantsSpawnManager.SelectPlantType,
                _plantsSpawnManager.PlantRemovingSwitch);
        }
    }
}