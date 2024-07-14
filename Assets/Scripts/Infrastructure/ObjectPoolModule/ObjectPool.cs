using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.ObjectPoolModule
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly Transform _parentTransform;
        private readonly T _objectPrefab;
        
        private readonly ObjectsPoolFactory<T> _objectsFactory;
        private readonly Queue<T> _objectPoolQueue;

        public int ObjectPoolCount => _objectPoolQueue.Count;
        
        public ObjectPool(T objectPrefab, Transform parentTransform, int poolLength)
        {
            _parentTransform = parentTransform;
            _objectPrefab = objectPrefab;
            
            _objectsFactory = new ObjectsPoolFactory<T>();
            _objectPoolQueue = new Queue<T>();
            InstantiateObjectPool(poolLength);
        }

        public T GetObject()
        {
            return _objectPoolQueue.Count > 0 ? SelectObject() : CreateObject(true);
        }

        public void ReturnToPool(T objectToPool)
        {
            objectToPool.gameObject.SetActive(false);
            objectToPool.gameObject.transform.position = Vector3.zero;
            _objectPoolQueue.Enqueue(objectToPool);
        }

        private void InstantiateObjectPool(int poolLength)
        {
            for (int i = 0; i < poolLength; i++)
            {
                _objectPoolQueue.Enqueue(CreateObject(false));
            }
        }

        private T CreateObject(bool isActive)
        {
            T createdObject = _objectsFactory.Instantiate(_objectPrefab, _parentTransform, isActive);
            return createdObject;
        }

        private T SelectObject()
        {
            T selectedObject = _objectPoolQueue.Dequeue();
            selectedObject.gameObject.SetActive(true);
            return selectedObject;
        }
    }
}