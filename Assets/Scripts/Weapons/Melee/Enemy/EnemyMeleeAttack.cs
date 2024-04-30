using Audio;
using ProjectTools;
using Scripts.Animators;
using Scripts.Configs;
using Scripts.Enemies;
using Scripts.Enums;
using UnityEngine;
using Zenject;

namespace Scripts.Weapons.Melee
{
    public class EnemyMeleeAttack : MonoBehaviour
    {
        [Inject] private SerializableDictionary<EEnemyType, EnemyConfig> _enemyConfigs;
        
        [SerializeField] private MeleePoint _meleePoint;

        private LocalAudioService _audioService;
        private EnemyConfig _config;
        private EnemyController _enemyController;
        private CustomAnimator _animator;
        
        private int _damage;
        
        private void Awake()
        {
            _audioService = GetComponent<LocalAudioService>();
            _enemyController = GetComponent<EnemyController>();
            _animator = GetComponent<CustomAnimator>();
            _config = _enemyConfigs[_enemyController.EnemyType];
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
            _audioService.Play(EClipType.Swing);
            _animator.Play(EAnimationType.Attack); 
        }
        
        private void OnAttack()
        {
            if (_meleePoint.CanAttack & _meleePoint.EnemyHealth != null)
            {
                _audioService.Play(EClipType.Punch);
                _meleePoint.EnemyHealth.GetDamage(_damage);
            }
            _enemyController.Stay(false);
            _animator.Play(EAnimationType.Idle);
        }
    } 
}
