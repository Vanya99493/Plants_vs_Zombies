using System;
using CustomClasses;
using ZombiesModule;

namespace LevelModule.Data
{
    [Serializable]
    public class Wave
    {
        public float WaveTime;
        public SerializableDictionary<ZombieType, int> ZombiesDuringWave;
        public SerializableDictionary<ZombieType, int> ZombiesDuringFinalWaveFight;
    }
}