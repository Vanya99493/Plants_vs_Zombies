﻿using System.Collections.Generic;
using UnityEngine;

namespace LevelModule
{
    [CreateAssetMenu(fileName = "LevelSO", menuName = "Levels/LevelSO", order = 1)]
    public class LevelSO : ScriptableObject
    {
        public int StartCoinsAmount;
        public List<Wave> Waves;
    }
}