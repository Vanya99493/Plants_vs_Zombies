using Infrastructure.AbstractFactoryModule;
using UnityEngine;

namespace Infrastructure.ObjectPoolModule
{
    public class ObjectsPoolFactory<T> : AbstractFactory<T> where T : MonoBehaviour
    {
        public override T Instantiate(T objectPrefab, Transform parentTransform, bool isActive = true)
        {
            T spawnedObject = Object.Instantiate(objectPrefab, parentTransform);
            spawnedObject.gameObject.SetActive(isActive);
            return spawnedObject;
        }

        public override T Instantiate(T objectPrefab, Transform parentTransform, Vector3 spawnPosition, bool isActive = true)
        {
            T spawnedObject = Object.Instantiate(objectPrefab, parentTransform);
            spawnedObject.gameObject.transform.position = spawnPosition;
            spawnedObject.gameObject.SetActive(isActive);
            return spawnedObject;
        }
    }
}