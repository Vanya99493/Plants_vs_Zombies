using System;
using Interfaces;
using UnityEngine;

namespace LevelModule
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ShotParticle : MonoBehaviour, IDestroyable
    {
        public event Action<IDestroyable> DestroyEvent;

        [SerializeField] private ParticleSystem _particles;

        private void Awake()
        {
            _particles ??= GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            _particles.Play();
        }

        public void Destroy()
        {
            _particles.Stop();
            DestroyEvent?.Invoke(this);
            DestroyEvent = null;
        }
    }
}