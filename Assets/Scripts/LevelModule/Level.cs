﻿using Infrastructure;
using ObjectLoaderModule;
using PlaygroundModule;
using UIModule.LevelModule;
using UnityEngine;

namespace LevelModule
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private LevelDifficultyType _levelDifficultyType;
        [SerializeField] private DIContainer _diContainer;
        [SerializeField] private LevelUIController _levelUIController;
        [SerializeField] private PlantsSpawnManager _plantsSpawnManager;
        [SerializeField] private ZombiesSpawner _zombiesSpawner;

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
            InitializeGameHud();

            _plantsSpawnManager.SpawnPlantEvent += _coinsHolder.WithdrawCoins;
            
            _wavesController.StartSpawnZombies(levelSO);
        }

        private void InitializeGameHud()
        {
            _levelUIController.InitializeGameHud(_plantsSpawnManager.SelectPlantType, 
                _plantsSpawnManager.SelectPlantType, 
                _plantsSpawnManager.SelectPlantType,
                _plantsSpawnManager.PlantRemovingSwitch,
                _coinsHolder);
        }
    }
}