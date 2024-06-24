using LevelModule;
using PlantsModule;
using UnityEngine;
using ZombiesModule;

namespace ObjectLoaderModule
{
    public static class ObjectLoader
    {
        private const string LEVELS_SO_NAME = "LevelsSO";
        private const string PLANTS_SO_NAME = "PlantsSO";
        private const string ZOMBIES_SO_NAME = "ZombiesSO";
        
        public static LevelSO LoadLevelSO(LevelDifficultyType levelDifficultyType)
        {
            LevelsSO levelsSO = Resources.Load<LevelsSO>(LEVELS_SO_NAME);
            return levelsSO.Levels[levelDifficultyType];
        }
        
        public static PlantSO LoadPlantSO(PlantType plantType)
        {
            PlantsSO plantsSO = Resources.Load<PlantsSO>(PLANTS_SO_NAME);
            return plantsSO.Plants[plantType];
        }

        public static ZombieSO LoadZombieSO(ZombieType zombieType)
        {
            ZombiesSO zombiesSO = Resources.Load<ZombiesSO>(ZOMBIES_SO_NAME);
            return zombiesSO.Zombies[zombieType];
        }
    }
}