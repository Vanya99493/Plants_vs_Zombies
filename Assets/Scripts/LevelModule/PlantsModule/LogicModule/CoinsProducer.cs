using System.Collections;
using Infrastructure;
using ObjectLoaderModule;
using UnityEngine;

namespace LevelModule
{
    public class CoinsProducer : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPositionTransform;
        [SerializeField] private PlantType _plantType;

        private CoinsSpawner _coinsSpawner;
        private int _coinsToProduce;
        private float _coinsSpawnDelay;
        
        private void Awake()
        {
            var plantSO = ObjectLoader.LoadPlantSO(_plantType);
            _coinsToProduce = plantSO.CoinsToSpawn;
            _coinsSpawnDelay = plantSO.CoinsSpawnDelay;

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
                var coin = _coinsSpawner.SpawnCoin(_spawnPositionTransform.position);
                coin.Initialize(_coinsToProduce);
            }
        }
    }
}