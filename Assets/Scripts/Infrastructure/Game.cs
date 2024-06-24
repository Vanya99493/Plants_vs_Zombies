using LevelModule;
using PlaygroundModule;
using UIModule;
using UnityEngine;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private UIController _uiController;
        [SerializeField] private PlantsSpawnManager _plantsSpawnManager;
        [SerializeField] private ZombiesSpawnManager _zombiesSpawnManager;

        private Level _currentLevel;
        
        private void Awake()
        {
            InitializeUI();
            
            StartNewLevel();
        }

        private void StartNewLevel(LevelDifficultyType levelDifficultyType = LevelDifficultyType.Easy)
        {
            _currentLevel = new Level(_uiController, _plantsSpawnManager, _zombiesSpawnManager);
            _currentLevel.StartLevel(levelDifficultyType);
        }

        private void InitializeUI()
        {
            
        }
    }
}