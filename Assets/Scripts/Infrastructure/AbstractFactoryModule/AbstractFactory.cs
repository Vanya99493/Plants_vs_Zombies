using UnityEngine;

namespace Infrastructure
{
    public abstract class AbstractFactory<T>
    {
        public abstract T Instantiate(T objectPrefab, Transform parentTransform, bool isActive = true);
        public abstract T Instantiate(T objectPrefab, Transform parentTransform, Vector3 spawnPosition, bool isActive = true);
    }
}