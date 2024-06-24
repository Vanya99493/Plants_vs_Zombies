using System;
using UnityEngine;

namespace ZombiesModule
{
    public abstract class Zombie : MonoBehaviour
    {
        public event Action<Zombie> DeathEvent;

        protected float _speed;

        public void Initialize(float speed)
        {
            _speed = speed;
        }
        
        protected void FixedUpdate()
        {
            Move();
        }

        protected void Move()
        {
            Vector3 direction = new(-1f, 0f, 0f);
            transform.position += direction * (Time.fixedDeltaTime * _speed);
        }
    }
}