using System.Collections;
using Infrastructure;
using Infrastructure.ObjectPoolModule;
using Interfaces;
using UnityEngine;

namespace LevelModule
{
    public class CoinsSpawner : MonoBehaviour
    {
        private const float SHOT_PARTICLE_LIFE_TIME = 1f;

        [SerializeField] private int _poolLength;
        [Header("Coin")]
        [SerializeField] private Transform _coinsParentToSpawn;
        [SerializeField] private Coin _coinPrefab;
        [Header("Particles")] 
        [SerializeField] private Transform _particlesParentToSpawn;
        [SerializeField] private PickUpParticle _pickUpCoinParticlePrefab;

        private ObjectPool<Coin> _coinsObjectPool;
        private ObjectPool<PickUpParticle> _pickUpCoinParticlesObjectPool;
        private CoinsHolder _coinsHolder;

        private void Awake()
        {
            _coinsObjectPool = new ObjectPool<Coin>(_coinPrefab, _coinsParentToSpawn, _poolLength);
            _pickUpCoinParticlesObjectPool = new ObjectPool<PickUpParticle>(_pickUpCoinParticlePrefab, 
                _particlesParentToSpawn, _poolLength);
        }

        public void Initialize(CoinsHolder coinsHolder)
        {
            _coinsHolder = coinsHolder;
        }

        public Coin SpawnCoin(Vector3 coinSpawnPosition)
        {
            var spawnedCoin = SpawnCoinObject(coinSpawnPosition);
            return spawnedCoin;
        }

        public Coin SpawnCoinForTime(Vector3 coinSpawnPosition, float lifeTime)
        {
            Coin spawnedCoin = SpawnCoinObject(coinSpawnPosition);

            Coroutine returnToPoolCoroutine = StartCoroutine(ReturnCoinToPoolAfterTime(spawnedCoin, lifeTime));
            spawnedCoin.DestroyEvent += destroyableCoin => StopCoroutine(returnToPoolCoroutine);
            
            return spawnedCoin;
        }

        private Coin SpawnCoinObject(Vector3 spawnPosition)
        {
            Coin spawnedCoin = _coinsObjectPool.GetObject();
            spawnedCoin.transform.position = spawnPosition;
            spawnedCoin.PickUpEvent += _coinsHolder.AddCoins;
            spawnedCoin.DestroyEvent += OnCoinDestroy;
            return spawnedCoin;
        }

        private IEnumerator ReturnCoinToPoolAfterTime(Coin coin, float time)
        {
            yield return new WaitForSeconds(time);
            coin.Destroy();
        }

        private void OnCoinDestroy(IDestroyable destroyableCoin)
        {
            SpawnPickUpCoinParticle(((Coin)destroyableCoin).gameObject.transform.position);
            _coinsObjectPool.ReturnToPool(destroyableCoin as Coin);
        }

        private void SpawnPickUpCoinParticle(Vector3 spawnPosition)
        {
            PickUpParticle pickUpParticle = _pickUpCoinParticlesObjectPool.GetObject();
            pickUpParticle.transform.position = spawnPosition;
            pickUpParticle.DestroyEvent += OnPickUpParticleDestroy;
            StartCoroutine(DestroyParticleCoroutine(pickUpParticle));
        }

        private IEnumerator DestroyParticleCoroutine(PickUpParticle pickUpParticle)
        {
            yield return new WaitForSeconds(SHOT_PARTICLE_LIFE_TIME);
            pickUpParticle.Destroy();
        }

        private void OnPickUpParticleDestroy(IDestroyable destroyableParticle)
        {
            _pickUpCoinParticlesObjectPool.ReturnToPool(destroyableParticle as PickUpParticle);
        }
    }
}