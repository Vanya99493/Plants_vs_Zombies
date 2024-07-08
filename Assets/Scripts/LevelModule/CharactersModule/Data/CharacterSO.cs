using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace LevelModule.CharactersModule
{
    public class CharacterSO : ScriptableObject
    {
        public string Name;
        public int HealthPoints;
        public Sprite Icon;
        public string Info;
        public List<Ability> Abilities;
        
        public T GetAbility<T>() where T : Ability
        {
            foreach (var ability in Abilities)
            {
                if (ability is T)
                {
                    return ability as T;
                }
            }

            throw new Exception($"Cannot find ability with type \"{typeof(T)}\"");
        }
        
        public string GetInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Has {HealthPoints} HP\n");
            stringBuilder.Append($"{Info}\n");
            foreach (var ability in Abilities)
            {
                stringBuilder.Append(ability.GetInfo());
            }
            return stringBuilder.ToString();
        }
    }
}