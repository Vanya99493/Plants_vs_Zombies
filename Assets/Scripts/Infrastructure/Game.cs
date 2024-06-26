using System;
using System.Collections.Generic;
using Infrastructure.Interfaces;
using LevelModule;
using PlaygroundModule;
using UIModule;
using UnityEngine;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        public static Dictionary<Type, IService> Services= new();

        [SerializeField] private UIController _uiController;
        [SerializeField] private PlantsSpawnManager _plantsSpawnManager;
        [SerializeField] private ZombiesSpawner _zombiesSpawner;
        [SerializeField] private CoinsSpawner _coinsSpawner;
        [SerializeField] private BulletsSpawner _bulletsSpawner;

        private Level _currentLevel;
        
        private void Awake()
        {
            InitializeUI();
            InitializeServices();
            
            StartNewLevel();
        }

        private void InitializeUI()
        {
            
        }

        private void InitializeServices()
        {
            Services.Add(_coinsSpawner.GetType(), _coinsSpawner);
            Services.Add(_bulletsSpawner.GetType(), _bulletsSpawner);
        }

        private void StartNewLevel(LevelDifficultyType levelDifficultyType = LevelDifficultyType.Easy)
        {
            _currentLevel = new Level(_uiController, _plantsSpawnManager, _zombiesSpawner);
            _currentLevel.StartLevel(levelDifficultyType);
        }
    }
}