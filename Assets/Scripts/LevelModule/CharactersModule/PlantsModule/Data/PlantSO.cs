using UnityEngine;

namespace LevelModule.CharactersModule
{
    [CreateAssetMenu(fileName = "PlantSO", menuName = "Plants/PlantSO", order = 1)]
    public class PlantSO : ScriptableObject
    {
        public Plant Prefab;
        public Sprite Icon;
        public int Price;
        public int HealthPoints;
        public DamageConfig DamageConfig;
        public CoinGenerateConfig CoinGenerateConfig;
    }
}