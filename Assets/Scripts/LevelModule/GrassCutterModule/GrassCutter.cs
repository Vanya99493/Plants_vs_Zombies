﻿using System;
using Infrastructure.ObjectLoaderModule;
using Interfaces;
using UnityEngine;

namespace LevelModule.GrassCutterModule
{
    public class GrassCutter : MonoBehaviour
    {
        public event Action StartMoveEvent;
        
        [SerializeField] private GrassCutterTrigger _grassCutterTrigger;

        private float _currentSpeed;
        private float _maxSpeed;
        
        private void Awake()
        {
            var grassCutterSO = ObjectLoader.LoadGrassCutterSO();
            _maxSpeed = grassCutterSO.Speed;
            _grassCutterTrigger.Initialize(grassCutterSO.TriggerLayer);
            
            _grassCutterTrigger.TriggerEnterEvent += OnGrassCutterTriggerEnter;
        }

        private void OnGrassCutterTriggerEnter(GameObject collidedObject)
        {
            if (_currentSpeed == 0)
            {
                _currentSpeed = _maxSpeed;
                StartMoveEvent?.Invoke();
            }

            if (collidedObject.TryGetComponent<IDestroyable>(out var destroyableObject))
            {
                destroyableObject.Destroy();
            }
        }

        private void FixedUpdate()
        {
            if (_currentSpeed == 0)
            {
                return;
            }

            Move();
        }

        private void Move()
        {
            transform.position += Vector3.right * (_currentSpeed * Time.fixedDeltaTime);
        }
    }
}