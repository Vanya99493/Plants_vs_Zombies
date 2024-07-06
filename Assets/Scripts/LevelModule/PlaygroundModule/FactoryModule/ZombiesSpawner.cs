using Interfaces;
using ObjectLoaderModule;
using UnityEngine;

namespace LevelModule
{
    public class ZombiesSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositionsTransforms;
        [SerializeField] private Transform _parentToSpawnTrasnofrm;
        [SerializeField] private CoinsSpawner _coinsSpawner;

        private int _coinSpawnChance;
        private float _coinLifeTime;
        private int _coinsToSpawn;
        
        public void Initialize(int coinSpawnChance, float coinLifeTime, int coinsToSpawn)
        {
            _coinSpawnChance = coinSpawnChance;
            _coinLifeTime = coinLifeTime;
            _coinsToSpawn = coinsToSpawn;
        }
        
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
            spawnedZombie.transform.position = spawnPosition;
            spawnedZombie.Initialize(zombieSO.HealthPoints);
            spawnedZombie.DestroyEvent += OnZombieDestroy;
            return spawnedZombie;
        }

        private void OnZombieDestroy(IDestroyable zombie)
        {
            if (Random.Range(0, 100) < _coinSpawnChance)
            {
                var spawnedCoin = _coinsSpawner.SpawnCoinForTime(((Zombie)zombie).transform.position, _coinLifeTime);
                spawnedCoin.Initialize(_coinsToSpawn);
            }
            Destroy((zombie as Zombie)?.gameObject);
        }
    }
}