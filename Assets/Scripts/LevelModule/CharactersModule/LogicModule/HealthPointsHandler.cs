using System;
using Interfaces;
using UnityEngine;

namespace LevelModule.CharactersModule
{
    public class HealthPointsHandler : MonoBehaviour, IDestroyable, IDamagable
    {
        public event Action<IDestroyable> DestroyEvent;
        public event Action<int, int> UpdateHealthEvent;
        
        private int _healthPoints;
        private int _maxHealthPoints;

        public int CurrentHealthPoints => _healthPoints;
        public int MaxHealthPoints => _maxHealthPoints;
        
        public void Initialize(int maxHealthPoints, int currentHealthPoints = -1)
        {
            _maxHealthPoints = maxHealthPoints;
            _healthPoints = currentHealthPoints == -1 ? _maxHealthPoints : currentHealthPoints;
            UpdateHealthEvent?.Invoke(_healthPoints, _maxHealthPoints);
        }
        
        public void CauseDamage(int damage)
        {
            _healthPoints = damage >= _healthPoints ? 0 : _healthPoints - damage;
            UpdateHealthEvent?.Invoke(_healthPoints, _maxHealthPoints);

            if (_healthPoints <= 0)
            {
                Destroy();
            }
        }
        
        public void Destroy()
        {
            DestroyEvent?.Invoke(this);

            DestroyEvent = null;
            UpdateHealthEvent = null;
        }
    }
}