using ObjectLoaderModule;
using UnityEngine;

namespace ZombiesModule
{
    public class ZombieMover : MonoBehaviour, IZombieState
    {
        [SerializeField] private ZombieType _zombieType;
        
        private float _speed;
        private float _currentSpeed;

        private void Awake()
        {
            _speed = ObjectLoader.LoadZombieSO(_zombieType).Speed;
            _currentSpeed = 0;
        }

        public void Enter()
        {
            _currentSpeed = _speed;
        }

        public void Exit()
        {
            _currentSpeed = 0f;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector3 direction = new(-1f, 0f, 0f);
            transform.position += direction * (Time.fixedDeltaTime * _currentSpeed);
        }
    }
}