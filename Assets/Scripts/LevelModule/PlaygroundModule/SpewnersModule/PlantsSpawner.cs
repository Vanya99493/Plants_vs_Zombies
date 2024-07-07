using System;
using System.Collections.Generic;
using CustomClasses;
using Infrastructure;
using Interfaces;
using LevelModule.CharactersModule;
using ObjectLoaderModule;
using UnityEngine;

namespace LevelModule
{
    public class PlantsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _parentToSpawnTransform;
        [SerializeField] private SerializableDictionary<PlantType, int> _objectPoolsLengths;
        
        private Dictionary<Type, PlantType> _plantsTypes = new()
        {
            { typeof(Sunflower), PlantType.Sunflower },
            { typeof(Peeshooter), PlantType.Peeshooter },
            { typeof(Wallnut), PlantType.Wallnut }
        };
        
        private Dictionary<PlantType, ObjectPool<Plant>> _plantsObjectPools;

        private void Awake()
        {
            _plantsObjectPools = new();

            foreach (var objectPoolLength in _objectPoolsLengths)
            {
                _plantsObjectPools.Add(
                    objectPoolLength.Key, 
                    new ObjectPool<Plant>(
                        ObjectLoader.LoadPlantSO(objectPoolLength.Key).Prefab,
                        _parentToSpawnTransform,
                        objectPoolLength.Value
                    )
                );
            }
        }
        
        public Plant Spawn(Cell cell, PlantType plantType, out int plantPrice)
        {
            var plantSO = ObjectLoader.LoadPlantSO(plantType);
            plantPrice = plantSO.Price;
            
            var plant = _plantsObjectPools[plantType].GetObject();
            plant.Initialize(plantSO.HealthPoints);
            plant.DestroyEvent += OnPlantDestroy;
            cell.SetPlant(plant);

            return plant;
        }
        
        private void OnPlantDestroy(IDestroyable plant)
        {
            _plantsObjectPools[_plantsTypes[plant.GetType()]].ReturnToPool(plant as Plant);
        }
    }
}