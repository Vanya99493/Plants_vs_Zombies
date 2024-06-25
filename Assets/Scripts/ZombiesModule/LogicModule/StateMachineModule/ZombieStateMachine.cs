using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZombiesModule
{
    public class ZombieStateMachine : MonoBehaviour
    {
        [SerializeField] private IZombieState[] _zombieStates;

        private Dictionary<Type, IZombieState> _zombieStatesMap;
        private IZombieState _currentZombieState;

        private void Awake()
        {
            _zombieStatesMap = new();
            for (int i = 0; i < _zombieStates.Length; i++)
            {
                _zombieStatesMap.Add(_zombieStates[i].GetType(), _zombieStates[i]);
            }
        }

        public void Enter<T>() where T : IZombieState
        {
            _currentZombieState?.Exit();
            _currentZombieState = _zombieStatesMap[typeof(T)];
            _currentZombieState.Enter();
        }
    }
}