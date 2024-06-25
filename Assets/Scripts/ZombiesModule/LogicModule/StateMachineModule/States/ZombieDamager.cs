using ObjectLoaderModule;
using UnityEngine;

namespace ZombiesModule
{
    public class ZombieDamager : MonoBehaviour, IZombieState
    {
        [SerializeField] private ZombieType _zombieType;

        private int _damage;

        private void Awake()
        {
            _damage = ObjectLoader.LoadZombieSO(_zombieType).Damage;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}