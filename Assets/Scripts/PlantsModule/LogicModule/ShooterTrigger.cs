using System;
using UnityEngine;

namespace PlantsModule
{
    public class ShooterTrigger : MonoBehaviour
    {
        public event Action<int> TriggerEnterEvent;
        public event Action<int> TriggerExitEvent;

        [SerializeField] private LayerMask _triggerLayer;
        
        private int _trackedObjectsCount;
        
        private void OnTriggerEnter(Collider other)
        {
            if ((_triggerLayer.value & (1 << other.gameObject.layer)) != 0)
            {
                _trackedObjectsCount++;
                TriggerEnterEvent?.Invoke(_trackedObjectsCount);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if ((_triggerLayer.value & (1 << other.gameObject.layer)) != 0)
            {
                _trackedObjectsCount--;
                TriggerExitEvent?.Invoke(_trackedObjectsCount);
            }
        }
    }
}