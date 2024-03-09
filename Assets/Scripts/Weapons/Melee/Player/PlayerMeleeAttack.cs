using Scripts.Animators;
using Scripts.Configs;
using Scripts.Enums;
using Scripts.Player;
using UnityEngine;
using Zenject;

namespace  Scripts.Weapons.Melee
{
    [RequireComponent(typeof(AudioSource))]
    public class MeleeAttackController : MonoBehaviour
    {
        [Inject] private PlayerConfig _playerConfig;
    
        [SerializeField] private MeleePoint _meleePoint;

        [Header("Sounds")] 
        [SerializeField] private AudioClip _swingAudio;
        [SerializeField] private AudioClip _punchAudio;
        
        private AudioSource _audioSource;
        private CustomAnimator _animator;
        
        private int _damage;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<CustomAnimator>();
        }

        private void Start()
        {
            _damage = _playerConfig.Damage;
        }

        private void Update()
        {
            if (Input.GetKeyDown((KeyCode.J)))
            {
                Attack();
            }
        }
        private void Attack()
        {
            _audioSource.clip = _swingAudio;
            _audioSource.Play();
            
            _animator.Play(EAnimationType.Attack); 
        }
        
        private void OnAttack()
        {
            if (_meleePoint.CanAttack & _meleePoint.EnemyHealth != null)
            {
                _meleePoint.EnemyHealth.GetDamage(_damage);
                
                _audioSource.clip = _punchAudio; //TODO maybe local audio Service?
                _audioSource.Play();
            }
            _animator.Play(EAnimationType.Idle);
        }
    }
}