using System;
using UnityEngine;

namespace LevelModule.GrassCutterModule
{
    public class GrassCutterTrigger : MonoBehaviour
    {
        public event Action<GameObject> TriggerEnterEvent;
        
        private LayerMask _triggerLayer;

        public void Initialize(LayerMask layerMask)
        {
            _triggerLayer = layerMask;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if ((_triggerLayer.value & (1 << other.gameObject.layer)) != 0)
            {
                TriggerEnterEvent?.Invoke(other.gameObject);
            }
        }
    }
}