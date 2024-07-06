﻿using System;
using System.Collections;
using Infrastructure;
using ObjectLoaderModule;
using UnityEngine;

namespace LevelModule
{
    public class CoinsProducer : MonoBehaviour
    {
        public event Action ProduceCoinEvent;
        
        [SerializeField] private Transform _spawnPositionTransform;
        [SerializeField] private PlantType _plantType;

        private CoinsSpawner _coinsSpawner;
        private int _coinsToProduce;
        private float _coinsSpawnDelay;
        private float _coinsLifeTime;
        
        private void Awake()
        {
            var plantSO = ObjectLoader.LoadPlantSO(_plantType);
            _coinsToProduce = plantSO.CoinGenerateConfig.CoinsToSpawn;
            _coinsSpawnDelay = plantSO.CoinGenerateConfig.CoinsSpawnDelay;
            _coinsLifeTime = plantSO.CoinGenerateConfig.CoinsLifeTime; 

            StartCoroutine(CoinsSpawnCoroutine());
        }

        private void Start()
        {
            _coinsSpawner = DIContainer.GetService<CoinsSpawner>();
        }

        private IEnumerator CoinsSpawnCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_coinsSpawnDelay);
                var coin = _coinsLifeTime == 0
                    ? _coinsSpawner.SpawnCoin(_spawnPositionTransform.position)
                    : _coinsSpawner.SpawnCoinForTime(_spawnPositionTransform.position, _coinsLifeTime);
                coin.Initialize(_coinsToProduce);
                ProduceCoinEvent?.Invoke();

                while (coin != null)
                {
                    yield return null;
                }
            }
        }
    }
}