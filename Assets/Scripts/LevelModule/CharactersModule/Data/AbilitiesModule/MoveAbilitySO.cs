using UnityEngine;

namespace LevelModule.CharactersModule
{
    [CreateAssetMenu(fileName = "MoveAbilitySO", menuName = "Characters/Abilities/MoveAbilitySO")]
    public class MoveAbilitySO : Ability
    {
        public float Speed;
        
        public override string GetInfo() =>
            Speed != 0 ? $"Can move {Speed} m/s.\n" : "";
    }
}