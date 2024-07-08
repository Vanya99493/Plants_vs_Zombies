namespace LevelModule.CharactersModule
{
    [System.Serializable]
    public class CoinGenerateConfig
    {
        public int CoinsToSpawn;
        public int CoinsSpawnDelay;
        public float CoinsLifeTime;

        public string GetInfo() => CoinsToSpawn != 0 ? $"Generate {CoinsToSpawn} dollars every {CoinsSpawnDelay} seconds.\n" : ""; 
    }
}