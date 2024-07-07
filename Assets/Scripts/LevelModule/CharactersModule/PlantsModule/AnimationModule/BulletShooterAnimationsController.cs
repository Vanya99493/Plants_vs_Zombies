using UnityEngine;

namespace LevelModule.CharactersModule
{
    [RequireComponent(typeof(Animator), typeof(BulletShooter))]
    public class BulletShooterAnimationsController : MonoBehaviour
    {
        private const string SHOOT_TRIGGER_NAME = "Shoot";

        [SerializeField] private Animator _animator;
        [SerializeField] private BulletShooter _bulletShooter;

        private void Awake()
        {
            _animator ??= GetComponent<Animator>();
            _bulletShooter ??= GetComponent<BulletShooter>();
        }

        private void Start()
        {
            _bulletShooter.ShootEvent += OnShoot;
        }

        private void OnShoot()
        {
            _animator.SetTrigger(SHOOT_TRIGGER_NAME);
        }
    }
}