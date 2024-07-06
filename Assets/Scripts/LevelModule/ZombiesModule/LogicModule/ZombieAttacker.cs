using System;
using Interfaces;
using ObjectLoaderModule;
using UnityEngine;

namespace LevelModule
{
    public class ZombieAttacker : MonoBehaviour
    {
        public event Action<bool> AttackingEvent;
        
        [SerializeField] private ZombieType _zombieType;
        [SerializeField] private ZombieTrigger _zombieTrigger;
        
        private float _reloadTime;
        private float _speed;
        private int _damage;
        private GameObject _trackedObject;
        
        public void Awake()
        {
            var zombieSO = ObjectLoader.LoadZombieSO(_zombieType);
            
            _speed = zombieSO.Speed;
            _damage = zombieSO.Damage;

            _zombieTrigger.TriggerEnterEvent += trackedObject => _trackedObject = trackedObject;
            _zombieTrigger.TriggerExitEvent += trackedObject => _trackedObject = trackedObject;
        }
        
        private void FixedUpdate()
        {
            if (_trackedObject == null)
            {
                AttackingEvent?.Invoke(false);
                Move();
                return;
            }

            AttackingEvent?.Invoke(true);
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

        private void Move()
        {
            Vector3 direction = new(-1f, 0f, 0f);
            transform.position += direction * (Time.fixedDeltaTime * _speed);
        }
    }
}