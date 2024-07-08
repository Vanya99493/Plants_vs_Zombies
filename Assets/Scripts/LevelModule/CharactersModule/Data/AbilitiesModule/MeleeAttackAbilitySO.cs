using UnityEngine;

namespace LevelModule.CharactersModule
{
    [CreateAssetMenu(fileName = "MeleeAttackAbilitySO", menuName = "Characters/Abilities/MeleeAttackAbilitySO")]
    public class MeleeAttackAbilitySO : Ability
    {
        public int Damage;
        public float Distance;
        public float ShotsPerSecond;

        public override string GetInfo() => 
            Damage != 0 ? $"Damage enemy by {Damage} hp every {1f / ShotsPerSecond} seconds with melee attacks.\n" : "";
    }
}