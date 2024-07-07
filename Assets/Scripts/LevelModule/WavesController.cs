using System.Collections;
using System.Collections.Generic;
using CustomClasses;
using Interfaces;
using LevelModule.CharactersModule;
using UnityEngine;

namespace LevelModule
{
    public class WavesController
    {
        private ZombiesSpawner _zombiesSpawner;

        private int _zombiesToDestroy;
        private int _destroyedZombies;
        private bool _isWaveEnded = false;
        
        public WavesController(ZombiesSpawner zombiesSpawner)
        {
            _zombiesSpawner = zombiesSpawner;
        }

        public void StartSpawnZombies(LevelSO levelSO)
        {
            _zombiesSpawner.StartCoroutine(SpawnZombies(levelSO));
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
                    Zombie spawnedZombie = _zombiesSpawner.SpawnZombie(zombieType);
                    spawnedZombie.DestroyEvent += OnZombieDestroy;
                    
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
                    Zombie spawnedZombie = _zombiesSpawner.SpawnZombie(zombieType);
                    spawnedZombie.DestroyEvent += OnZombieDestroy;
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

        private void OnZombieDestroy(IDestroyable zombie)
        {
            _destroyedZombies++;
            if (_destroyedZombies >= _zombiesToDestroy)
            {
                _isWaveEnded = true;
            }
        }
    }
}