using System.Collections;
using System.Collections.Generic;
using CustomClasses;
using ObjectLoaderModule;
using PlaygroundModule;
using UIModule;
using UnityEngine;
using ZombiesModule;

namespace LevelModule
{
    public class Level
    {
        private PlantsSpawnManager _plantsSpawnManager;
        private ZombiesSpawner _zombiesSpawner;

        private WavesController _wavesController;
        
        public Level(UIController uiController, PlantsSpawnManager plantsSpawnManager, ZombiesSpawner zombiesSpawner)
        {
            _plantsSpawnManager = plantsSpawnManager;
            _zombiesSpawner = zombiesSpawner;
            
            InitializeGameHud(uiController);

            _wavesController = new WavesController(_zombiesSpawner);
        }
        
        public void StartLevel(LevelDifficultyType levelDifficultyType = LevelDifficultyType.Easy)
        {
            LevelSO levelSO = ObjectLoader.LoadLevelSO(levelDifficultyType);
            _wavesController.StartSpawnZombies(levelSO);
        }

        private List<ZombieType> GetZombiesList(SerializableDictionary<ZombieType, int> zombiesMap)
        {
            List<ZombieType> zombies = new();
            foreach (var zombiesGroup in zombiesMap)
            {
                for (int i = 0; i < zombiesGroup.Value; i++)
                {
                    zombies.Add(zombiesGroup.Key);
                }
            }

            return zombies;
        }

        private void InitializeGameHud(UIController uiController)
        {
            uiController.InitializeGameHud(_plantsSpawnManager.SelectPlantType, 
                _plantsSpawnManager.SelectPlantType, 
                _plantsSpawnManager.SelectPlantType,
                _plantsSpawnManager.PlantRemovingSwitch);
        }
    }
}