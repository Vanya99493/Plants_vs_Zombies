using ObjectLoaderModule;
using UnityEngine;
using ZombiesModule;

namespace PlaygroundModule
{
    public class ZombiesSpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositionsTransforms;
        [SerializeField] private Transform _parentToSpawnTrasnofrm;

        public Zombie[] SpawnZombies(ZombieType[] zombiesTypes)
        {
            Zombie[] spawnedZombies = new Zombie[zombiesTypes.Length];

            for (int i = 0; i < zombiesTypes.Length; i++)
            {
                spawnedZombies[i] = SpawnZombie(zombiesTypes[i]);
            }

            return spawnedZombies;
        }

        public Zombie SpawnZombie(ZombieType zombieType)
        {
            if (zombieType == ZombieType.None)
            {
                return null;
            }

            Vector3 spawnPosition = _spawnPositionsTransforms[Random.Range(0, _spawnPositionsTransforms.Length)].position;

            var zombieSO = ObjectLoader.LoadZombieSO(zombieType);
            var spawnedZombie = Instantiate(zombieSO.Prefab, _parentToSpawnTrasnofrm);
            spawnedZombie.Initialize(zombieSO.Speed);
            spawnedZombie.transform.position = spawnPosition;
            spawnedZombie.DeathEvent += OnDestroy;
            return spawnedZombie;
        }

        private void OnDestroy(Zombie zombie)
        {
            Destroy(zombie.gameObject);
        }
    }
}