using UnityEngine;

namespace LevelModule.CharactersModule
{
    [CreateAssetMenu(fileName = "PlantSO", menuName = "Characters/Plants/PlantSO")]
    public class PlantSO : CharacterSO
    {
        public Plant Prefab;
        public int Price;
    }
}