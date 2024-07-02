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
        public List<Wave> Waves;
    }
}