using System.Collections;
using UnityEngine;

namespace LevelModule
{
    public class RandomCoinsSpawnManager : MonoBehaviour
    {
        [SerializeField] private CoinsSpawner _coinsSpawner;
        [SerializeField] private Transform[] _spawnTransforms;

        private float _lowerTimeSpawnLimit;
        private float _upperTimeSpawnLimit;
        private int _coinsToSpawn;
        private float _coinsLifeTime;
        private float _coinSpeed;
        
        public void Initialize(float lowerTimeSpawnLimit, float upperTimeSpawnLimit, int coinsToSpawn, float coinsLifeTime, float coinSpeed)
        {
            _lowerTimeSpawnLimit = lowerTimeSpawnLimit;
            _upperTimeSpawnLimit = upperTimeSpawnLimit;
            _coinsToSpawn = coinsToSpawn;
            _coinsLifeTime = coinsLifeTime;
            _coinSpeed = coinSpeed;
        }

        public void StartSpawnCoins()
        {
            StartCoroutine(SpawnCoinsCoroutine());
        }

        private  IEnumerator SpawnCoinsCoroutine()
        {
            float delayTime;
            while (true)
            {
                delayTime = Random.Range(_lowerTimeSpawnLimit, _upperTimeSpawnLimit);
                yield return new WaitForSeconds(delayTime);
                Vector3 spawnPosition = _spawnTransforms[Random.Range(0, _spawnTransforms.Length)].position;

                var spawnedCoin = _coinsLifeTime == 0
                    ? _coinsSpawner.SpawnCoin(spawnPosition)
                    : _coinsSpawner.SpawnCoinForTime(spawnPosition, _coinsLifeTime);
                spawnedCoin.Initialize(_coinsToSpawn);
                
                StartCoroutine(MoveCoinCoroutine(spawnedCoin));
            }
        }

        private IEnumerator MoveCoinCoroutine(Coin coinToMove)
        {
            while (coinToMove != null)
            {
                coinToMove.transform.Translate(-Vector3.forward * (_coinSpeed * Time.fixedDeltaTime));
                yield return null;
            }
        }
    }
}