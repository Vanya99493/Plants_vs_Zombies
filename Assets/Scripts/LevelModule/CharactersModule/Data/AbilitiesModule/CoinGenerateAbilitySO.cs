using UnityEngine;

namespace LevelModule.CharactersModule
{
    [CreateAssetMenu(fileName = "CoinGenerateAbilitySO", menuName = "Characters/Abilities/CoinGenerateAbilitySO")]
    public class CoinGenerateAbilitySO : Ability
    {
        public int CoinsToSpawn;
        public int CoinsSpawnDelay;
        public float CoinsLifeTime;
        
        public override string GetInfo() =>
            CoinsToSpawn != 0 ? $"Generate {CoinsToSpawn} dollars every {CoinsSpawnDelay} seconds.\n" : "";
    }
}