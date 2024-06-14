using PlantsModule;
using UnityEngine;

namespace ObjectLoaderModule
{
    public static class ObjectLoader
    {
        public static Plant LoadPlant(PlantType plantType)
        {
            PlantsSO plantsSO = Resources.Load<PlantsSO>("PlantsSO");
            return plantsSO.Plants[plantType];
        }
    }
}