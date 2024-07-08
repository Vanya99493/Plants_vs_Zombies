using UnityEngine;

namespace LevelModule.CharactersModule
{
    public abstract class Ability : ScriptableObject
    {
        public abstract string GetInfo();
    }
}