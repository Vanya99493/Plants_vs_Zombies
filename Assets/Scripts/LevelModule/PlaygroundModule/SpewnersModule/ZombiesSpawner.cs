using System;
using System.Collections.Generic;
using CustomClasses;
using Infrastructure;
using Interfaces;
using LevelModule.CharactersModule;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelModule
{
    public class ZombiesSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositionsTransforms;
        [SerializeField] private Transform _parentToSpawnTrasnform;
        [SerializeField] private CoinsSpawner _coinsSpawner;
        [SerializeField] private SerializableDictionary<ZombieType, int> _objectPoolsLengths;

        private Dictionary<Type, ZombieType> _zombieTypes = new()
        {
            { typeof(SimpleZombie), ZombieType.Simple },
            { typeof(ConeArmouredZombie), ZombieType.ConeArmoured },
            { typeof(HelmetArmouredZombie), ZombieType.HelmetArmoured }
        };
        
        private Dictionary<ZombieType, ObjectPool<Zombie>> _zombiesObjectPools;
        private int _coinSpawnChance;
        private float _coinLifeTime;
        private int _coinsToSpawn;

        private void Awake()
        {
            _zombiesObjectPools = new();

            foreach (var objectPoolLength in _objectPoolsLengths)
            {
                _zombiesObjectPools.Add(
                    objectPoolLength.Key, 
                    new ObjectPool<Zombie>(
                        ObjectLoader.LoadZombieSO(objectPoolLength.Key).Prefab,
                        _parentToSpawnTrasnform,
                        objectPoolLength.Value
                        )
                    );
            }
        }

        public void Initialize(int coinSpawnChance, float coinLifeTime, int coinsToSpawn)
        {
            _coinSpawnChance = coinSpawnChance;
            _coinLifeTime = coinLifeTime;
            _coinsToSpawn = coinsToSpawn;
        }

        public Zombie SpawnZombie(ZombieType zombieType)
        {
            if (zombieType == ZombieType.None)
            {
                return null;
            }

            Vector3 spawnPosition = _spawnPositionsTransforms[Random.Range(0, _spawnPositionsTransforms.Length)].position;

            var zombieSO = ObjectLoader.LoadZombieSO(zombieType);
            var spawnedZombie = _zombiesObjectPools[zombieType].GetObject();
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
            _zombiesObjectPools[_zombieTypes[zombie.GetType()]].ReturnToPool(zombie as Zombie);
        }
    }
}