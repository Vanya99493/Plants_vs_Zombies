using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class DIContainer : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> _servicesList;

        private static Dictionary<Type, MonoBehaviour> Services = new();

        public void Initialize()
        {
            foreach (var service in _servicesList)
            {
                Services.TryAdd(service.GetType(), service);
            }
        }

        public static T GetService<T>() where T : MonoBehaviour
        {
            return Services[typeof(T)] as T;
        }

        private void OnDestroy()
        {
            Services = new();
        }
    }
}