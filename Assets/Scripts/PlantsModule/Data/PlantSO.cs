using UnityEngine;

namespace PlantsModule
{
    [CreateAssetMenu(fileName = "PlantSO", menuName = "Plants/PlantSO", order = 1)]
    public class PlantSO : ScriptableObject
    {
        public Plant Prefab;
        public int HealthPoints;
        public int Damage;
        public int Distance;
        public float RegeneratePerSecond;
        [Header("Coin production")] 
        public int CoinsToSpawn;
        public int CoinsSpawnDelay;
    }
}