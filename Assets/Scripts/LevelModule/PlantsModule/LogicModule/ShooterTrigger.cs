using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace LevelModule
{
    public class ShooterTrigger : MonoBehaviour
    {
        public event Action<int> TriggerEnterEvent;
        public event Action<int> TriggerExitEvent;

        [SerializeField] private LayerMask _triggerLayer;

        private List<IDestroyable> _trackedObjects = new();
        
        private void OnTriggerEnter(Collider other)
        {
            if ((_triggerLayer.value & (1 << other.gameObject.layer)) != 0)
            {
                if (other.gameObject.TryGetComponent<IDestroyable>(out var destroyableObject))
                {
                    _trackedObjects.Add(destroyableObject);
                    TriggerEnterEvent?.Invoke(_trackedObjects.Count);
                    destroyableObject.DestroyEvent += OnObjectDestroy;
                }
            }
        }

        private void OnObjectDestroy(IDestroyable destroyableObject)
        {
            _trackedObjects.Remove(destroyableObject);
            TriggerExitEvent?.Invoke(_trackedObjects.Count);
        }

        private void OnDestroy()
        {
            foreach (var trackedObject in _trackedObjects)
            {
                trackedObject.DestroyEvent -= OnObjectDestroy;
            }
            _trackedObjects.Clear();
        }
    }
}