using CustomClasses;
using UnityEngine;

namespace LevelModule.Data
{
    [CreateAssetMenu(fileName = "LevelsSO", menuName = "Levels/LevelsSO", order = 0)]
    public class LevelsSO : ScriptableObject
    {
        public SerializableDictionary<LevelDifficultyType, LevelSO> Levels;
    }
}