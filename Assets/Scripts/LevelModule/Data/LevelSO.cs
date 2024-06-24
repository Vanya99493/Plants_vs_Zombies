using System.Collections.Generic;
using UnityEngine;

namespace LevelModule.Data
{
    [CreateAssetMenu(fileName = "LevelSO", menuName = "Levels/LevelSO", order = 1)]
    public class LevelSO : ScriptableObject
    {
        public List<Wave> Waves;
    }
}