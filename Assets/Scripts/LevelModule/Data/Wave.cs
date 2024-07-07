using System;
using CustomClasses;
using LevelModule.CharactersModule;

namespace LevelModule
{
    [Serializable]
    public class Wave
    {
        public float WaveTime;
        public SerializableDictionary<ZombieType, int> ZombiesDuringWave;
        public SerializableDictionary<ZombieType, int> ZombiesDuringFinalWaveFight;
    }
}