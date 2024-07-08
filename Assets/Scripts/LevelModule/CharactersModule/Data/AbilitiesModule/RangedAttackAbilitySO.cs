using UnityEngine;

namespace LevelModule.CharactersModule
{
    [CreateAssetMenu(fileName = "RangedAttackAbilitySO", menuName = "Characters/Abilities/RangedAttackAbilitySO")]
    public class RangedAttackAbilitySO : Ability
    {
        public int Damage;
        public float BulletSpeed;
        public float ShotsPerSecond;
        
        public override string GetInfo() => 
            Damage != 0 ? $"Damage enemy by {Damage} hp every {1f / ShotsPerSecond} seconds with ranged attacks.\n" : "";
    }
}