using Infrastructure;
using Infrastructure.SceneLoaderModule;
using ObjectLoaderModule;
using UIModule.LevelModule;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelModule
{
    public class Level : MonoBehaviour
    {
        private const int MAIN_SCENE_INDEX = 0;
        private const string WIN_LEVEL_MESSAGE = "You win!";
        private const string LOSE_LEVEL_MESSAGE = "You lose...";
        
        [SerializeField] private LevelDifficultyType _levelDifficultyType;
        [SerializeField] private DIContainer _diContainer;
        [SerializeField] private LevelUIController _levelUIController;
        [SerializeField] private Headquarters _headquarters; 
        [Header("Spawners")]
        [SerializeField] private PlantsSpawnManager _plantsSpawnManager;
        [SerializeField] private ZombiesSpawner _zombiesSpawner;
        [SerializeField] private CoinsSpawner _coinsSpawner;
        [SerializeField] private RandomCoinsSpawnManager _randomCoinsSpawnManager;

        private WavesController _wavesController;
        private CoinsHolder _coinsHolder;

        private void Awake()
        {
            if (_diContainer != null)
            {
                _diContainer.Initialize();
            }

            StartLevel();
        }
        
        private void StartLevel()
        {
            LevelSO levelSO = ObjectLoader.LoadLevelSO(_levelDifficultyType);
            _coinsHolder = new CoinsHolder(levelSO.StartCoinsAmount);
            _wavesController = new WavesController(_zombiesSpawner);
            _wavesController.WavesEndEvent += OnWavesEnd;
            _headquarters.HeadquartersAchieveEvent += OnHeadquartersAchieve;
            
            InitializeUI();
            InitializeSpawners(levelSO);
            
            _wavesController.StartSpawnZombies(levelSO);
            _randomCoinsSpawnManager.StartSpawnCoins();
        }

        private void InitializeUI()
        {
            _levelUIController.InitializeGameHud(_plantsSpawnManager.SelectPlantType,
                _plantsSpawnManager.PlantRemovingSwitch, 
                PauseGame,
                _coinsHolder);
            _levelUIController.InitializePauseMenu(ResumeGame, RestartLevel, ExitLevel);
            _levelUIController.InitializeGameOverPanel(RestartLevel, ExitLevel);
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
        }

        private void ResumeGame()
        {
            Time.timeScale = 1f;
        }
        
        private void RestartLevel()
        {
            ResumeGame();
            string currentSceneName = SceneManager.GetActiveScene().name;
            new SceneLoader().LoadScene(MAIN_SCENE_INDEX);
            new SceneLoader().LoadScene(currentSceneName);
        }

        private void ExitLevel()
        {
            ResumeGame();
            new SceneLoader().LoadScene(MAIN_SCENE_INDEX);
        }

        private void InitializeSpawners(LevelSO levelSO)
        {
            _coinsSpawner.Initialize(_coinsHolder);
            _plantsSpawnManager.SpawnPlantEvent += _coinsHolder.WithdrawCoins;
            _zombiesSpawner.Initialize(levelSO.CoinsFromZombieSpawnConfig.CoinFromZombiesSpawnChanceInPercentage, 
                levelSO.CoinsFromZombieSpawnConfig.CoinFromZombiesLifeTimeInSeconds,
                levelSO.CoinsFromZombieSpawnConfig.CoinsFromZombiesToSpawn);
            _randomCoinsSpawnManager.Initialize(levelSO.RandomCoinsSpawnConfig.LowerTimeSpawnLimit,
                levelSO.RandomCoinsSpawnConfig.UpperTimeSpawnLimit,
                levelSO.RandomCoinsSpawnConfig.CoinsToSpawn,
                levelSO.RandomCoinsSpawnConfig.CoinLifeTime,
                levelSO.RandomCoinsSpawnConfig.CoinMoveSpeed);
        }

        private void OnWavesEnd()
        {
            PauseGame();
            _levelUIController.ActivateGameOverPanel(WIN_LEVEL_MESSAGE);
        }

        private void OnHeadquartersAchieve()
        {
            PauseGame();
            _levelUIController.ActivateGameOverPanel(LOSE_LEVEL_MESSAGE);
        }
    }
}