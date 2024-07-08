using UnityEngine;

namespace LevelModule.CharactersModule
{
    [CreateAssetMenu(fileName = "PlantSO", menuName = "Plants/PlantSO", order = 1)]
    public class PlantSO : ScriptableObject
    {
        public string Name;
        public Plant Prefab;
        public Sprite Icon;
        public int Price;
        public int HealthPoints;
        public DamageConfig DamageConfig;
        public CoinGenerateConfig CoinGenerateConfig;
        public string Info;

        public string GetInfo() => $"{Info}\n{DamageConfig.GetInfo()}{CoinGenerateConfig.GetInfo()}";
    }
}