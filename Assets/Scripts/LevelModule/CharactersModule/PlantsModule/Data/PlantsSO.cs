using CustomClasses;
using UnityEngine;

namespace LevelModule.CharactersModule
{
    [CreateAssetMenu(fileName = "PlantsSO", menuName = "Plants/PlantsSO", order = 0)]
    public class PlantsSO : ScriptableObject
    {
        public SerializableDictionary<PlantType, PlantSO> Plants;
    }
}
