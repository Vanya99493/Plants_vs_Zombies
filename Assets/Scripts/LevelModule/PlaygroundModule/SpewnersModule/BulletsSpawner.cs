using System.Collections;
using Infrastructure;
using Infrastructure.ObjectPoolModule;
using Interfaces;
using UnityEngine;

namespace LevelModule
{
    public class BulletsSpawner : MonoBehaviour
    {
        private const float SHOT_PARTICLE_LIFE_TIME = 1f;
        
        [SerializeField] private int _poolLength;
        [Header("Bullet")]
        [SerializeField] private Transform _bulletParentToSpawn;
        [SerializeField] private Bullet _bulletPrefab;
        [Header("Particles")] 
        [SerializeField] private Transform _particlesParentToSpawn;
        [SerializeField] private ShotParticle shotParticlePrefab;

        private ObjectPool<Bullet> _bulletsObjectPool;
        private ObjectPool<ShotParticle> _shotParticlesObjectPool;

        private void Awake()
        {
            _bulletsObjectPool = new ObjectPool<Bullet>(_bulletPrefab, _bulletParentToSpawn, _poolLength);
            _shotParticlesObjectPool = new ObjectPool<ShotParticle>(shotParticlePrefab, _particlesParentToSpawn, _poolLength);
        }

        public Bullet SpawnBullet(Vector3 bulletSpawnPosition)
        {
            var spawnedBullet = SpawnBulletObject(bulletSpawnPosition);
            return spawnedBullet;
        }

        public Bullet SpawnBullet(Vector3 bulletSpawnPosition, Vector3 particleSpawnPosition)
        {
            var spawnedBullet = SpawnBulletObject(bulletSpawnPosition);
            SpawnShotParticleObject(particleSpawnPosition);
            return spawnedBullet;
        }

        private Bullet SpawnBulletObject(Vector3 spawnPosition)
        {
            Bullet spawnedBullet = _bulletsObjectPool.GetObject();
            spawnedBullet.transform.position = spawnPosition;
            spawnedBullet.DestroyEvent += OnBulletDestroy;
            return spawnedBullet;
        }

        private void SpawnShotParticleObject(Vector3 spawnPosition)
        {
            ShotParticle spawnedShotParticle = _shotParticlesObjectPool.GetObject();
            spawnedShotParticle.transform.position = spawnPosition;
            spawnedShotParticle.DestroyEvent += OnParticleDestroy;
            StartCoroutine(DestroyParticleCoroutine(spawnedShotParticle));
        }

        private IEnumerator DestroyParticleCoroutine(ShotParticle particleToDestroy)
        {
            yield return new WaitForSeconds(SHOT_PARTICLE_LIFE_TIME);
            particleToDestroy.Destroy();
        }

        private void OnBulletDestroy(IDestroyable destroyedBullet)
        {
            _bulletsObjectPool.ReturnToPool(destroyedBullet as Bullet);
        }

        private void OnParticleDestroy(IDestroyable destroyableParticle)
        {
            _shotParticlesObjectPool.ReturnToPool(destroyableParticle as ShotParticle);
        }
    }
}