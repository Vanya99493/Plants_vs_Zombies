using System;
using Interfaces;
using UnityEngine;

namespace PlantsModule
{
    public abstract class Plant : MonoBehaviour, IDamagable
    {
        public event Action<Plant> DeathEvent; 

        protected int _healthPoints;
        
        public void Initialize(int healthPoints)
        {
            _healthPoints = healthPoints;
        }

        public void CauseDamage(int damage)
        {
            _healthPoints = damage >= _healthPoints ? 0 : _healthPoints - damage;

            if (_healthPoints <= 0)
            {
                DeathEvent?.Invoke(this);
            }
        }
    }
}