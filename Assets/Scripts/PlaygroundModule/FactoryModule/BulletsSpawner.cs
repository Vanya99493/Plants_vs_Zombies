using BulletsModule;
using UnityEngine;

namespace PlaygroundModule
{
    public class BulletsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _parentToSpawn;
        [SerializeField] private Bullet _bulletPrefab;
        
        public Bullet SpawnBullet(Vector3 spawnPosition)
        {
            Bullet spawnedBullet = Instantiate(_bulletPrefab, _parentToSpawn);
            spawnedBullet.transform.position = spawnPosition;

            return spawnedBullet;
        }
    }
}