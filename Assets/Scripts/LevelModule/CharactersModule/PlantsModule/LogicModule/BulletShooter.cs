using System;
using System.Collections;
using Infrastructure;
using UnityEngine;

namespace LevelModule.CharactersModule
{
    public class BulletShooter : MonoBehaviour
    {
        public event Action ShootEvent;
        
        [SerializeField] private PlantType _plantType;
        [SerializeField] private ShooterTrigger _shooterTrigger;
        [SerializeField] private Transform _bulletsSpawnTransform;
        [SerializeField] private Transform _particlesSpawnTransform;
        [SerializeField] private LayerMask _collidedLayerMask;
        
        private BulletsSpawner _bulletsSpawner;
        private int _damage;
        private float _bulletSpeed;
        private float _shotsDelay;
        private Coroutine _shootCoroutine;
        
        private void Awake()
        {
            var plantShooterAbility = ObjectLoader.LoadPlantSO(_plantType).GetAbility<RangedAttackAbilitySO>();

            _damage = plantShooterAbility.Damage;
            _bulletSpeed = plantShooterAbility.BulletSpeed;
            _shotsDelay = 1f / plantShooterAbility.ShotsPerSecond;
            
            _shooterTrigger.TriggerEnterEvent += OnTriggerEvent;
            _shooterTrigger.TriggerExitEvent += OnTriggerEvent;
        }

        private void Start()
        {
            _bulletsSpawner = DIContainer.GetService<BulletsSpawner>();
        }

        private void OnTriggerEvent(int trackedObjectsCount)
        {
            if (trackedObjectsCount <= 0 && _shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
                _shootCoroutine = null;
            }
            else if(_shootCoroutine == null)
            {
                _shootCoroutine = StartCoroutine(ShootCoroutine());
            }
        }

        private IEnumerator ShootCoroutine()
        {
            while (true)
            {
                Shoot();
                yield return new WaitForSeconds(_shotsDelay);
            }
        }

        private void Shoot()
        {
            var bullet = _particlesSpawnTransform != null
                ? _bulletsSpawner.SpawnBullet(_bulletsSpawnTransform.position, _particlesSpawnTransform.position)
                : _bulletsSpawner.SpawnBullet(_bulletsSpawnTransform.position);
            bullet.Initialize(_collidedLayerMask, transform.right, _bulletSpeed, _damage);
            ShootEvent?.Invoke();
        }
    }
}