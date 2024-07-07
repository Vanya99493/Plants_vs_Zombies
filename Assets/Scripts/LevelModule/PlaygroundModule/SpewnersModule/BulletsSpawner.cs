using Infrastructure;
using Interfaces;
using UnityEngine;

namespace LevelModule
{
    public class BulletsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _parentToSpawn;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _poolLength;

        private ObjectPool<Bullet> _bulletsObjectPool;

        private void Awake()
        {
            _bulletsObjectPool = new ObjectPool<Bullet>(_bulletPrefab, _parentToSpawn, _poolLength);
        }

        public Bullet SpawnBullet(Vector3 spawnPosition)
        {
            Bullet spawnedBullet = _bulletsObjectPool.GetObject();
            spawnedBullet.transform.position = spawnPosition;
            spawnedBullet.DestroyEvent += OnBulletDestroy;

            return spawnedBullet;
        }

        private void OnBulletDestroy(IDestroyable destroyedBullet)
        {
            _bulletsObjectPool.ReturnToPool(destroyedBullet as Bullet);
        }
    }
}