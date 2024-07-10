using System.Collections.Generic;
using UnityEngine;

namespace LevelModule
{
    [CreateAssetMenu(fileName = "LevelSO", menuName = "Levels/LevelSO", order = 1)]
    public class LevelSO : ScriptableObject
    {
        public int StartCoinsAmount;
        public CoinsFromZombieSpawnConfig CoinsFromZombieSpawnConfig;
        public RandomCoinsSpawnConfig RandomCoinsSpawnConfig;
        [Header("Waves settings")] 
        public float PrepareTime;
        public List<Wave> Waves;
    }
}