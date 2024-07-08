using System;
using UnityEngine;

namespace LevelModule
{
    public class Headquarters : MonoBehaviour
    {
        public event Action HeadquartersAchieveEvent;

        [SerializeField] private LayerMask _triggerLayer;

        private void OnTriggerEnter(Collider other)
        {
            if ((_triggerLayer.value & (1 << other.gameObject.layer)) != 0)
            {
                HeadquartersAchieveEvent?.Invoke();
            }
        }
    }
}