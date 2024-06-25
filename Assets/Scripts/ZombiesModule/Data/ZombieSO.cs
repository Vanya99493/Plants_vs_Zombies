using UnityEngine;

namespace ZombiesModule
{
    [CreateAssetMenu(fileName = "ZombieSO", menuName = "Zombies/ZombieSO", order = 1)]
    public class ZombieSO : ScriptableObject
    {
        public Zombie Prefab;
        public int HealthPoints;
        public int Damage;
        public float Distance;
        public float Speed;
    }
}