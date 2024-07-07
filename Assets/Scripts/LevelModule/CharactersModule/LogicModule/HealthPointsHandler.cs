using System;
using Interfaces;
using UnityEngine;

namespace LevelModule.CharactersModule
{
    public class HealthPointsHandler : MonoBehaviour, IDestroyable, IDamagable
    {
        public event Action<IDestroyable> DestroyEvent;
        public event Action<int, int> CauseDamageEvent;
        
        private int _healthPoints;
        private int _maxHealthPoints;

        public int CurrentHealthPoints => _healthPoints;
        public int MaxHealthPoints => _maxHealthPoints;
        
        public void Initialize(int maxHealthPoints, int currentHealthPoints = -1)
        {
            _maxHealthPoints = maxHealthPoints;
            _healthPoints = currentHealthPoints == -1 ? _maxHealthPoints : currentHealthPoints;
        }
        
        public void CauseDamage(int damage)
        {
            _healthPoints = damage >= _healthPoints ? 0 : _healthPoints - damage;
            CauseDamageEvent?.Invoke(_healthPoints, _maxHealthPoints);

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