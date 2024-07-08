namespace LevelModule.CharactersModule
{
    [System.Serializable]
    public class DamageConfig
    {
        public int Damage;
        public float BulletSpeed;
        public float ShotsPerSecond;

        public string GetInfo() => Damage != 0 ? $"Damage enemy by {Damage} hp every {1f / ShotsPerSecond} seconds with ranged attacks.\n" : "";
    }
}