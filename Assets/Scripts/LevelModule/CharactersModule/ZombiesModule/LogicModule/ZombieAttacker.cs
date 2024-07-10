using System;
using Infrastructure;
using Interfaces;
using UnityEngine;

namespace LevelModule.CharactersModule
{
    public class ZombieAttacker : MonoBehaviour
    {
        public event Action<bool> AttackingEvent;
        
        [SerializeField] private ZombieType _zombieType;
        [SerializeField] private ZombieTrigger _zombieTrigger;
        
        private float _reloadTime;
        private float _speed;
        private int _damage;
        private float _shotsDelay;
        private GameObject _trackedObject;
        
        public void Awake()
        {
            var zombieSO = ObjectLoader.LoadZombieSO(_zombieType);
            
            _speed = zombieSO.GetAbility<MoveAbilitySO>().Speed;
            _damage = zombieSO.GetAbility<MeleeAttackAbilitySO>().Damage;
            _shotsDelay = 1f / zombieSO.GetAbility<MeleeAttackAbilitySO>().ShotsPerSecond;

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
                    _reloadTime = _shotsDelay;
                }
            }

            _reloadTime -= Time.fixedDeltaTime;
        }

        private void Move()
        {
            Vector3 direction = new(-1f, 0f, 0f);
            transform.position += direction * (Time.fixedDeltaTime * _speed);
        }

        private void OnDisable()
        {
            _trackedObject = null;
        }
    }
}