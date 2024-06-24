using System.Collections;
using System.Collections.Generic;
using CustomClasses;
using PlaygroundModule;
using UnityEngine;
using ZombiesModule;

namespace LevelModule
{
    public class WavesController
    {
        private ZombiesSpawnManager _zombiesSpawnManager;

        private int _zombiesToDestroy;
        private int _destroyedZombies;
        private bool _isWaveEnded = false;
        
        public WavesController(ZombiesSpawnManager zombiesSpawnManager)
        {
            _zombiesSpawnManager = zombiesSpawnManager;
        }

        public void StartSpawnZombies(LevelSO levelSO)
        {
            _zombiesSpawnManager.StartCoroutine(SpawnZombies(levelSO));
        }
        
        private IEnumerator SpawnZombies(LevelSO levelSO)
        {
            float waveTime;
            List<ZombieType> zombiesTypes;
            int currentZombieTypeIndex;
            float waitTime;
            
            foreach (var wave in levelSO.Waves)
            {
                waveTime = wave.WaveTime;
                zombiesTypes = GetZombiesList(wave.ZombiesDuringWave);
                _zombiesToDestroy = zombiesTypes.Count;
                _destroyedZombies = 0;
                currentZombieTypeIndex = 1;
                
                foreach (var zombieType in zombiesTypes)
                {
                    waitTime = currentZombieTypeIndex != _zombiesToDestroy
                        ? Random.Range(0.0f, waveTime - waveTime / 10f)
                        : Random.Range(0.0f, waveTime);
                    
                    if (waitTime < 1f)
                    {
                        waitTime = 1f;
                    }
                    waveTime -= waitTime;
                    
                    yield return new WaitForSeconds(waitTime);
                    Zombie spawnedZombie = _zombiesSpawnManager.SpawnZombie(zombieType);
                    spawnedZombie.DeathEvent += OnZombieDestroy;
                    
                    currentZombieTypeIndex++;
                }

                while (!_isWaveEnded)
                {
                    yield return null;
                }
                
                _isWaveEnded = false;

                zombiesTypes = GetZombiesList(wave.ZombiesDuringFinalWaveFight);
                _zombiesToDestroy = zombiesTypes.Count;
                _destroyedZombies = 0;

                foreach (var zombieType in zombiesTypes)
                {
                    yield return new WaitForSeconds(1f);
                    Zombie spawnedZombie = _zombiesSpawnManager.SpawnZombie(zombieType);
                    spawnedZombie.DeathEvent += OnZombieDestroy;
                }

                while (!_isWaveEnded)
                {
                    yield return null;
                }

                _isWaveEnded = false;
            }
        }

        private List<ZombieType> GetZombiesList(SerializableDictionary<ZombieType, int> zombiesMap)
        {
            List<ZombieType> zombies = new();
            foreach (var zombiesGroup in zombiesMap)
            {
                for (int i = 0; i < zombiesGroup.Value; i++)
                {
                    zombies.Add(zombiesGroup.Key);
                }
            }

            return zombies;
        }

        private void OnZombieDestroy(Zombie zombie)
        {
            _destroyedZombies++;
            if (_destroyedZombies >= _zombiesToDestroy)
            {
                _isWaveEnded = true;
            }
        }
    }
}