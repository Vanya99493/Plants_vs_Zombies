using System;
using Interfaces;
using UnityEngine;

namespace ZombiesModule
{
    public abstract class Zombie : MonoBehaviour, IDamagable
    {
        public event Action<Zombie> DeathEvent;

        //[SerializeField] protected ZombieStateMachine _zombieStateMachine;

        [SerializeField] private ZombieTrigger _zombieTrigger;
        
        private float _reloadTime;
        private GameObject _trackedObject;
        
        protected int _healthPoints;
        protected float _speed;
        protected int _damage;

        public void Initialize(int healthPoints, float speed, int damage)
        {
            _healthPoints = healthPoints;
            _speed = speed;
            _damage = damage;

            _zombieTrigger.TriggerEnterEvent += trackedObject => _trackedObject = trackedObject;
            _zombieTrigger.TriggerExitEvent += trackedObject => _trackedObject = trackedObject;
        }

        private void FixedUpdate()
        {
            if (_trackedObject == null)
            {
                Move();
                return;
            }

            if (_reloadTime <= 0)
            {
                if (_trackedObject.TryGetComponent(out IDamagable damagableObject))
                {
                    damagableObject.CauseDamage(_damage);
                    _reloadTime = 1f;
                }
            }

            _reloadTime -= Time.fixedDeltaTime;
        }
        
        public void CauseDamage(int damage)
        {
            _healthPoints = damage >= _healthPoints ? 0 : _healthPoints - damage;

            if (_healthPoints <= 0)
            {
                DeathEvent?.Invoke(this);
            }
        }

        private void Move()
        {
            Vector3 direction = new(-1f, 0f, 0f);
            transform.position += direction * (Time.fixedDeltaTime * _speed);
        }
    }
}