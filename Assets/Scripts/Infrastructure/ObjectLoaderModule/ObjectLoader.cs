using LevelModule;
using LevelModule.CharactersModule;
using LevelModule.GrassCutterModule.Data;
using UnityEngine;

namespace Infrastructure.ObjectLoaderModule
{
    public static class ObjectLoader
    {
        private const string LEVELS_SO_NAME = "LevelsSO";
        private const string PLANTS_SO_NAME = "PlantsSO";
        private const string ZOMBIES_SO_NAME = "ZombiesSO";
        private const string GRASS_CUTTER_SO_NAME = "GrassCutterSO";
        
        public static LevelSO LoadLevelSO(LevelDifficultyType levelDifficultyType)
        {
            return Resources.Load<LevelsSO>(LEVELS_SO_NAME).Levels[levelDifficultyType];
        }
        
        public static PlantSO LoadPlantSO(PlantType plantType)
        {
            return Resources.Load<PlantsSO>(PLANTS_SO_NAME).Plants[plantType];
        }

        public static ZombieSO LoadZombieSO(ZombieType zombieType)
        {
            return Resources.Load<ZombiesSO>(ZOMBIES_SO_NAME).Zombies[zombieType];
        }

        public static GrassCutterSO LoadGrassCutterSO()
        {
            return Resources.Load<GrassCutterSO>(GRASS_CUTTER_SO_NAME);;
        }
    }
}