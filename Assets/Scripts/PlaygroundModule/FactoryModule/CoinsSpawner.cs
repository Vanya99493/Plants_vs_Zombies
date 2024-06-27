using CoinsModule;
using UnityEngine;

namespace PlaygroundModule
{
    public class CoinsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _parentToSpawn;
        [SerializeField] private Coin _coinPrefab;

        public Coin SpawnCoin(Vector3 spawnPosition)
        {
            Coin spawnedCoin = Instantiate(_coinPrefab, _parentToSpawn);
            spawnedCoin.transform.position = spawnPosition;

            return spawnedCoin;
        }
    }
}