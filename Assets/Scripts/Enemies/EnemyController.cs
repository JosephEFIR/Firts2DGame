using Scripts.Animators;
using Scripts.Configs;
using Scripts.Enums;
using UnityEngine;
using Scripts.Player;
using Scripts.Managers;
using Scripts.TriggerScripts;
using Zenject;

namespace Scripts.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GroundCheck _groundCheck;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private JumpTrigger _jumpTrigger;

        [Inject] private HealthSystem _playerHealthSystem;
        [Inject] private PlayerController _player;
        
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private CustomAnimator _customAnimator;

        private int _heatlh;
        private int _damage;
        private float _speed;
        
        private float _distanceToTarget;
        private float _attackDistance;
        private float _visibleDistance;
        private float _maxDistancePursuit;
        private float _cooldown;
        private bool _isAttack = true;
        
        //Maybe create statContainer for stats?
        
        private float _horizontalAxis;
        private float _verticalAxis;
        private bool _isFacingRight = true;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _customAnimator = GetComponent<CustomAnimator>();
        }

        private void Start()
        {
            _heatlh = _enemyConfig.Healh;
            _damage = _enemyConfig.Damage;
            _speed = _enemyConfig.Speed;
            
            _distanceToTarget = _enemyConfig.AttackDistance;
            _attackDistance = _enemyConfig.AttackDistance;
            _visibleDistance = _enemyConfig.VisibleDistance;
            _maxDistancePursuit = _enemyConfig.MaxDistancePursuit;
            _cooldown = _enemyConfig.Cooldown;
            
            _customAnimator.Play(EAnimationType.Idle);
        }

        private void FixedUpdate()
        {
            if (_groundCheck.IsGround)
            {
                _customAnimator.SetMoveSpeed(_rigidbody2D.velocity.magnitude);
                
                _distanceToTarget = Vector3.Distance(_player.transform.position, gameObject.transform.position);
                if (_distanceToTarget <= _attackDistance)
                {
                    Attack();
                }
                else if (_distanceToTarget <= _visibleDistance)
                {
                    Walk();
                    _cooldown = _enemyConfig.Cooldown;
                }
            }
            if (_groundCheck.IsGround & _jumpTrigger.CanJump)
            {
                Debug.Log(_jumpTrigger.CanJump + " aaa?");
                Jump();
            }
        }

        private void Walk()
        {
            if (_player.transform.position.x < gameObject.transform.position.x)
            {
                _rigidbody2D.velocity = new Vector2(- _speed, 0); 
                _spriteRenderer.flipX = true;
            }
            else if (_player.transform.position.x > gameObject.transform.position.x)
            {
                _rigidbody2D.velocity = new Vector2(_speed, 0);
                _spriteRenderer.flipX = false;
            }
        }

        private void Jump()
        {
            _rigidbody2D.AddForce(Vector2.up * _enemyConfig.JumpForce  ,ForceMode2D.Impulse);
        }
        private void Attack()
        {
            if (_isAttack)
            {
                _customAnimator.Play(EAnimationType.Attack);
                
                _cooldown -= Time.deltaTime;
                if (_cooldown <= 0)
                {
                    _isAttack = false;
                    _playerHealthSystem.TakeDamage(_damage);
                }
            }
            else if (_isAttack == false)
            {
                _cooldown = _enemyConfig.Cooldown;
                _isAttack = true;
            }
        }

        public void GetDamage(int value)
        {
            _heatlh -= value;
        }
    }
}