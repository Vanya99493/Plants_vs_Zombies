using System;
using Interfaces;
using UnityEngine;

namespace LevelModule
{
    public abstract class Zombie : MonoBehaviour, IDamagable, IDestroyable
    {
        public event Action<IDestroyable> DestroyEvent;

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
                DestroyEvent?.Invoke(this);
            }
        }
        
        public void Destroy()
        {
            DestroyEvent?.Invoke(this);
        }
    }
}