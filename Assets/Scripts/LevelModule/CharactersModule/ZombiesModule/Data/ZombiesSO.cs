using CustomClasses;
using UnityEngine;

namespace LevelModule.CharactersModule
{
    [CreateAssetMenu(fileName = "ZombiesSO", menuName = "Zombies/ZombiesSO", order = 0)]
    public class ZombiesSO : ScriptableObject
    {
        public SerializableDictionary<ZombieType, ZombieSO> Zombies;
    }
}