using System.Collections;
using LevelModule.Data;
using PlaygroundModule;
using UIModule;
using UnityEngine;
using ZombiesModule;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private UIController _uiController;
        [SerializeField] private PlantsSpawnManager _plantsSpawnManager;
        [SerializeField] private ZombiesSpawnManager _zombiesSpawnManager;

        private void Awake()
        {
            InitializeUI();
        }

        private void Start()
        {
            StartLevel();
        }

        private void StartLevel(LevelDifficultyType levelDifficultyType = LevelDifficultyType.Easy)
        {
            // spawn enemies
        }

        private void InitializeUI()
        {
            _uiController.InitializeGameHud(_plantsSpawnManager.SelectPlantType, 
                _plantsSpawnManager.SelectPlantType, 
                _plantsSpawnManager.SelectPlantType);
        }
    }
}