using UnityEngine;

namespace LevelModule
{
    public class CoinsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _parentToSpawn;
        [SerializeField] private Coin _coinPrefab;

        private CoinsHolder _coinsHolder;

        public void Initialize(CoinsHolder coinsHolder)
        {
            _coinsHolder = coinsHolder;
        }

        public Coin SpawnCoin(Vector3 spawnPosition)
        {
            Coin spawnedCoin = Instantiate(_coinPrefab, _parentToSpawn);
            spawnedCoin.transform.position = spawnPosition;
            spawnedCoin.PickUpEvent += _coinsHolder.AddCoins;

            return spawnedCoin;
        }
    }
}