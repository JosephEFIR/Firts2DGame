using Assets.Scripts.Interfaces;
using Audio;
using ProjectTools;
using Scripts.Animators;
using Scripts.Configs;
using Scripts.Enemies;
using Scripts.Enums;
using UnityEngine;
using Zenject;

namespace Scripts.Health
{
    public class EnemyHealthSystem : MonoBehaviour, IHealthSystem
    {
        private LocalAudioService _audioService;
        
        private EnemyController _controller;
        private EnemyConfig _enemyConfig;
        
        private CustomAnimator _animator;
        private CapsuleCollider2D _colliderSize;
        
        private int _currentHealth;

        private void Awake()
        {
            _audioService = GetComponent<LocalAudioService>();
            _animator = GetComponent<CustomAnimator>();
            _colliderSize = GetComponent<CapsuleCollider2D>();
            _controller = GetComponent<EnemyController>();
            _enemyConfig = _controller.Config;
        }
        
        private void Start()
        {
            AddHealth(_enemyConfig.Health);
        }
        
        public void AddHealth(int value)
        {
            _currentHealth += value;
        }

        public void GetDamage(int value)
        {
            _audioService.Play(EClipType.GetDamage);
            _currentHealth -= value;
            if (_currentHealth <= 0)
            {
                Death(); return;
            }
            _animator.Play(EAnimationType.GetDamage);
        }

        public void Death()
        {
            _currentHealth = 0;
            _animator.Play(EAnimationType.Die);
            _audioService.Play(EClipType.Death);
            _colliderSize.size = new Vector2(0.3F,0.3F);
        }

        private void OnDeath()
        {
            gameObject.SetActive(false);
        }
    }
}