using UnityEngine;

namespace LevelModule
{
    [RequireComponent(typeof(Animator), typeof(ZombieAttacker))]
    public class ZombieAttackerAnimationsController : MonoBehaviour
    {
        private const string IS_ATTACKING_BOOL_NAME = "IsAttacking";

        [SerializeField] private Animator _animator;
        [SerializeField] private ZombieAttacker _zombieAttacker;

        private bool _isAttacking;
        
        private void Awake()
        {
            _animator ??= GetComponent<Animator>();
            _zombieAttacker ??= GetComponent<ZombieAttacker>();
        }

        private void Start()
        {
            _zombieAttacker.AttackingEvent += OnChangeAttackingState;
        }

        private void OnChangeAttackingState(bool isAttacking)
        {
            if (_isAttacking != isAttacking)
            {
                _isAttacking = isAttacking;
                _animator.SetBool(IS_ATTACKING_BOOL_NAME, _isAttacking);
            }
        }
    }
}