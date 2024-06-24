using PlantsModule;
using UnityEngine;
using ZombiesModule;

namespace ObjectLoaderModule
{
    public static class ObjectLoader
    {
        public static PlantSO LoadPlantSO(PlantType plantType)
        {
            PlantsSO plantsSO = Resources.Load<PlantsSO>("PlantsSO");
            return plantsSO.Plants[plantType];
        }

        public static ZombieSO LoadZombieSO(ZombieType zombieType)
        {
            ZombiesSO zombiesSO = Resources.Load<ZombiesSO>("ZombiesSO");
            return zombiesSO.Zombies[zombieType];
        }
    }
}