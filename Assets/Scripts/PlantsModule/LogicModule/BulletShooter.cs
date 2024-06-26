using System.Collections;
using Infrastructure;
using ObjectLoaderModule;
using PlaygroundModule;
using UnityEngine;

namespace PlantsModule
{
    public class BulletShooter : MonoBehaviour
    {
        [SerializeField] private PlantType _plantType;
        [SerializeField] private ShooterTrigger _shooterTrigger;
        [SerializeField] private Transform _bulletsSpawnTransform;
        [SerializeField] private LayerMask _collidedLayerMask;
        
        private BulletsSpawner _bulletsSpawner;
        private int _damage;
        private float _bulletSpeed;
        private Coroutine _shootCoroutine;
        
        private void Awake()
        {
            var plantSO = ObjectLoader.LoadPlantSO(_plantType);

            _damage = plantSO.Damage;
            _bulletSpeed = plantSO.BulletSpeed;
            
            _shooterTrigger.TriggerEnterEvent += OnTriggerEvent;
            _shooterTrigger.TriggerExitEvent += OnTriggerEvent;
        }

        private void Start()
        {
            _bulletsSpawner = Game.Services[typeof(BulletsSpawner)] as BulletsSpawner;
        }

        private void OnTriggerEvent(int trackedObjectsCount)
        {
            if (trackedObjectsCount <= 0)
            {
                StopCoroutine(ShootCoroutine());
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
                yield return new WaitForSeconds(1f);
            }
        }

        private void Shoot()
        {
            var bullet = _bulletsSpawner.SpawnBullet(_bulletsSpawnTransform.position);
            bullet.Initialize(_collidedLayerMask, transform.right, _bulletSpeed, _damage);
        }
    }
}