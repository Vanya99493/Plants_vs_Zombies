using Infrastructure.AudioModule;
using UnityEngine;

namespace LevelModule.CharactersModule
{
    [RequireComponent(typeof(BulletShooter))]
    public class BulletShooterBustedAudioController : BustedAudioController
    {
        [SerializeField] private BulletShooter _bulletShooter;

        protected override void Awake()
        {
            base.Awake();
            _bulletShooter ??= GetComponent<BulletShooter>();
        }

        private void Start()
        {
            _bulletShooter.ShootEvent += OnShoot;
        }

        private void OnShoot()
        {
            _audioSource.Play();
        }
    }
}