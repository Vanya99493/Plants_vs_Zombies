using System;
using Interfaces;
using UnityEngine;

namespace ZombiesModule
{
    public abstract class Zombie : MonoBehaviour, IDamagable
    {
        public event Action<Zombie> DeathEvent;

        //[SerializeField] protected ZombieStateMachine _zombieStateMachine;
        //[SerializeField] protected SphereCaster _sphereCaster;
        [SerializeField] private float _sphereRadius = 0.1f;
        [SerializeField] private LayerMask _layerMask;

        private float _maxDistance;
        private float _reloadTime;
        private GameObject _trackedObject;
        
        protected int _healthPoints;
        protected float _speed;
        protected int _damage;

        public void Initialize(int healthPoints, float speed, int damage, float distance)
        {
            _healthPoints = healthPoints;
            _speed = speed;
            _damage = damage;
            _maxDistance = distance;
        }

        private void FixedUpdate()
        {
            CastSphere();

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
        
        private void CastSphere()
        {
            _trackedObject = Physics.SphereCast(transform.position, _sphereRadius, -transform.right,
                out RaycastHit hit, _maxDistance, _layerMask)
                ? hit.transform.gameObject
                : null;
        }
    }
}