using System;
using System.Collections;
using System.Collections.Generic;
using CustomClasses;
using Interfaces;
using LevelModule.CharactersModule;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelModule
{
    public class WavesController
    {
        public event Action WavesEndEvent;
        
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
            foreach (var wave in levelSO.Waves)
            {
                yield return new WaitForSeconds(levelSO.PrepareTime);
                yield return _zombiesSpawner.StartCoroutine(SpawnZombiesDuringWave(wave));
                _isWaveEnded = false;
                yield return new WaitForSeconds(levelSO.PrepareTime);
                yield return _zombiesSpawner.StartCoroutine(SpawnZombiesDuringFinalWave(wave));
                _isWaveEnded = false;
            }

            WavesEndEvent?.Invoke();
        }

        private IEnumerator SpawnZombiesDuringWave(Wave wave)
        {
            float waveTime = wave.WaveTime;
            List<ZombieType> zombiesTypes = GetZombiesList(wave.ZombiesDuringWave);
            _zombiesToDestroy = zombiesTypes.Count;
            _destroyedZombies = 0;
            int currentZombieTypeIndex = 1;

            foreach (var zombieType in zombiesTypes)
            {
                if (currentZombieTypeIndex != 1)
                {
                    float waitTime = currentZombieTypeIndex != _zombiesToDestroy
                        ? Random.Range(0.0f, waveTime - waveTime / 10f)
                        : Random.Range(0.0f, waveTime);
                    
                    if (waitTime < 1f)
                    {
                        waitTime = 1f;
                    }
                    waveTime -= waitTime;
                    
                    yield return new WaitForSeconds(waitTime);
                }
                SpawnZombie(zombieType);
                currentZombieTypeIndex++;
            }

            while (!_isWaveEnded)
            {
                yield return null;
            }
        }

        private IEnumerator SpawnZombiesDuringFinalWave(Wave wave)
        {
            List<ZombieType> zombiesTypes = GetZombiesList(wave.ZombiesDuringFinalWaveFight);
            _zombiesToDestroy = zombiesTypes.Count;
            _destroyedZombies = 0;

            foreach (var zombieType in zombiesTypes)
            {
                yield return new WaitForSeconds(1f);
                SpawnZombie(zombieType);
            }

            while (!_isWaveEnded)
            {
                yield return null;
            }
        }

        private void SpawnZombie(ZombieType zombieType)
        {
            Zombie spawnedZombie = _zombiesSpawner.SpawnZombie(zombieType);
            spawnedZombie.DestroyEvent += OnZombieDestroy;
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