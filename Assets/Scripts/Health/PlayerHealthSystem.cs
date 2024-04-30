using System;
using Assets.Scripts.Interfaces;
using Audio;
using Scripts.Animators;
using Scripts.Configs;
using Scripts.Enums;
using Scripts.Managers;
using UnityEngine;
using Scripts.Player;
using Zenject;

namespace Scripts.Health
{
    public class PlayerHealthSystem : MonoBehaviour,IHealthSystem
    { 
        [Inject] private EventManager _eventManager;
        [Inject] private PlayerConfig _playerConfig;

        private CustomAnimator _animator;
        private PlayerController _playerController;
        private CapsuleCollider2D _colliderSize;
        private LocalAudioService _audioService;

        private int _currentHealth;
        public bool IsDead {get; private set; }
        
        private void Awake()
        {
            _animator = GetComponent<CustomAnimator>();
            _colliderSize = GetComponent<CapsuleCollider2D>();
            _playerController = GetComponent<PlayerController>();
            _audioService = GetComponent<LocalAudioService>();
        }

        private void Start()
        {
            AddHealth(_playerConfig.Health);
            IsDead = false;
        }

        public void AddHealth(int value)
        {
            _currentHealth += value;
            _currentHealth = Math.Clamp(_currentHealth, 1 , _playerConfig.MaxHealth);

            _eventManager.AddHealthUI(value);
        }
        
        public void GetDamage(int damage)
        {
            _currentHealth -= damage;
            _eventManager.TakeDamageUI(damage);
            
            if (_currentHealth <= 0)
            {
                Death(); return;
            }
            _animator.Play(EAnimationType.GetDamage);
            _audioService.Play(EClipType.GetDamage);
        }
        public void Death()
        {
            _currentHealth = 0;
            IsDead = true;
            
            _colliderSize.size = new Vector2(0.2F,0.2F);
            
            _playerController.Stay(true);
            _animator.Play(EAnimationType.Die);
            _audioService.Play(EClipType.Death);
            
            _eventManager.DeathUI();
        }
    }
}