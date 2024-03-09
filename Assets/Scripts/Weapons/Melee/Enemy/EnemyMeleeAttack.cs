using Scripts.Animators;
using Scripts.Configs;
using Scripts.Enemies;
using Scripts.Enums;
using UnityEngine;

namespace Scripts.Weapons.Melee
{
    public class EnemyMeleeAttack : MonoBehaviour
    {
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private MeleePoint _meleePoint;
        private EnemyController _enemyController;
        private CustomAnimator _animator;
        
        private int _damage;
        
        private void Awake()
        {
            _enemyController = GetComponent<EnemyController>();
            _animator = GetComponent<CustomAnimator>();
        }

        private void Start()
        {
            _damage = _config.Damage;
        }

        private void Update()
        {
            if (_meleePoint.CanAttack)
            {
                Attack();
            }
        }

        private void Attack()
        {
            _enemyController.Stay(true);
            _animator.Play(EAnimationType.Attack); 
        }
        
        private void OnAttack()
        {
            if (_meleePoint.CanAttack & _meleePoint.EnemyHealth != null)
            {
                _meleePoint.EnemyHealth.GetDamage(_damage);
            }
            _enemyController.Stay(false);
            _animator.Play(EAnimationType.Idle);
        }
    } 
}
