using System.Collections;
using Infrastructure;
using Interfaces;
using UnityEngine;

namespace LevelModule
{
    public class CoinsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _parentToSpawn;
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private int _poolLength;

        private ObjectPool<Coin> _coinsObjectPool;
        private CoinsHolder _coinsHolder;

        private void Awake()
        {
            _coinsObjectPool = new ObjectPool<Coin>(_coinPrefab, _parentToSpawn, _poolLength);
        }

        public void Initialize(CoinsHolder coinsHolder)
        {
            _coinsHolder = coinsHolder;
        }

        public Coin SpawnCoin(Vector3 spawnPosition)
        {
            Coin spawnedCoin = _coinsObjectPool.GetObject();
            spawnedCoin.transform.position = spawnPosition;
            spawnedCoin.PickUpEvent += _coinsHolder.AddCoins;
            spawnedCoin.DestroyEvent += OnCoinDestroy;

            return spawnedCoin;
        }

        public Coin SpawnCoinForTime(Vector3 spawnPosition, float lifeTime)
        {
            Coin spawnedCoin = _coinsObjectPool.GetObject();
            spawnedCoin.transform.position = spawnPosition;
            spawnedCoin.PickUpEvent += _coinsHolder.AddCoins;
            spawnedCoin.DestroyEvent += OnCoinDestroy;

            Coroutine returnToPoolCoroutine = StartCoroutine(ReturnCoinToPoolAfterTime(spawnedCoin, lifeTime));
            spawnedCoin.DestroyEvent += destroyableCoin => StopCoroutine(returnToPoolCoroutine);
            
            return spawnedCoin;
        }

        private IEnumerator ReturnCoinToPoolAfterTime(Coin coin, float time)
        {
            yield return new WaitForSeconds(time);
            coin.Destroy();
        }

        private void OnCoinDestroy(IDestroyable destroyableCoin)
        {
            _coinsObjectPool.ReturnToPool(destroyableCoin as Coin);
        }
    }
}