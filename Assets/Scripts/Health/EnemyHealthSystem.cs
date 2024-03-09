using Assets.Scripts.Interfaces;
using Scripts.Animators;
using Scripts.Configs;
using Scripts.Enums;
using UnityEngine;

namespace Scripts.Health
{
    public class EnemyHealthSystem : MonoBehaviour, IHealthSystem
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        private CustomAnimator _animator;
        private CapsuleCollider2D _colliderSize;
        private int _currentHealth;
        //TODO Умоляю сделай пожалуйста statContainer для обезьяны и других крипов. По кд в Сериализовать поле и выбирать, это такое себе... Или GetStat в конфиге сделай гений

        private void Awake()
        {
            _animator = GetComponent<CustomAnimator>();
            _colliderSize = GetComponent<CapsuleCollider2D>();
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
            _currentHealth -= value;
            if (_currentHealth <= 0)
            {
                Death();
            }
            _animator.Play(EAnimationType.GetDamage);
        }

        public void Death()
        {
            _currentHealth = 0;
            _animator.Play(EAnimationType.Die);
            _colliderSize.size = new Vector2(0.3F,0.3F);
        }

        private void OnDeath()
        {
            gameObject.SetActive(false);
        }
    }
}