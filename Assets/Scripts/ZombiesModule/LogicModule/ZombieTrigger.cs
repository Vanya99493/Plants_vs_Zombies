using System;
using UnityEngine;

namespace ZombiesModule
{
    public class ZombieTrigger : MonoBehaviour
    {
        public event Action<GameObject> TriggerEnterEvent;
        public event Action<GameObject> TriggerExitEvent;

        [SerializeField] private LayerMask _triggerLayer;
        
        private GameObject _trackedObject;
        
        private void OnTriggerEnter(Collider other)
        {
            if ((_triggerLayer.value & (1 << other.gameObject.layer)) != 0)
            {
                _trackedObject = other.gameObject;
                TriggerEnterEvent?.Invoke(_trackedObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if ((_triggerLayer.value & (1 << other.gameObject.layer)) != 0)
            {
                _trackedObject = null;
                TriggerExitEvent?.Invoke(_trackedObject);
            }
        }
    }
}