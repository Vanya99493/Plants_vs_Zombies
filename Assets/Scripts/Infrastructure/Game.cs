using System.Collections;
using PlaygroundModule;
using UIModule;
using UnityEngine;
using ZombiesModule;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private UIController _uiController;
        [SerializeField] private PlantsSpawnManager _plantsSpawnManager;
        [SerializeField] private ZombiesSpawnManager _zombiesSpawnManager;

        private void Awake()
        {
            InitializeUI();
        }

        private void Start()
        {
            StartCoroutine(SpawnEnemiesByDelay(3f));
        }

        private void InitializeUI()
        {
            _uiController.InitializeGameHud(_plantsSpawnManager.SelectPlantType, _plantsSpawnManager.SelectPlantType, _plantsSpawnManager.SelectPlantType);
        }

        private IEnumerator SpawnEnemiesByDelay(float delay)
        {
            ZombieType[] zombiesTypes =
            {
                ZombieType.Simple,
                ZombieType.ConeArmoured,
                ZombieType.BucketArmoured
            };
            int i = 0;

            while (true)
            {
                yield return new WaitForSeconds(delay);
                _zombiesSpawnManager.SpawnZombie(zombiesTypes[i % zombiesTypes.Length]);
            }
        }
    }
}