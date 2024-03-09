using Scripts.Animators;
using Scripts.Configs;
using Scripts.Enums;
using Scripts.Health;
using UnityEngine;
using Scripts.Player;
using Scripts.TriggerScripts;
using Zenject;

namespace Scripts.Enemies
{
    [RequireComponent(
        typeof(Rigidbody2D),
        typeof(CustomAnimator), 
        typeof(EnemyHealthSystem))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GroundCheck _groundCheck;
        [SerializeField] private EnemyConfig _enemyConfig;
        [Space]
        [SerializeField] private JumpTrigger _jumpTrigger;

        [Inject] private PlayerController _player;
        
        private Rigidbody2D _rigidbody2D;
        private CustomAnimator _customAnimator;
        
        private float _speed;
        private float _distanceToTarget;
        private float _visibleDistance;
        
        private bool _isFacingRight = true;
        private bool _stopWalk = false;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _customAnimator = GetComponent<CustomAnimator>();
        }

        private void Start()
        {
            _speed = _enemyConfig.Speed;
            _visibleDistance = _enemyConfig.VisibleDistance;

            _customAnimator.Play(EAnimationType.Idle);
        }

        private void FixedUpdate()
        {
            if (_stopWalk == false)
            {
                if (_groundCheck.IsGround)
                {
                    _distanceToTarget = Vector3.Distance(_player.transform.position, gameObject.transform.position);
                    if (_distanceToTarget <= _visibleDistance)
                    {
                        Move();
                    }
                }
                if (_groundCheck.IsGround & _jumpTrigger.CanJump)
                {
                    Jump();
                }
                FlipX();
            }
        }

        private void Move()
        {
            _customAnimator.SetMoveSpeed(_rigidbody2D.velocity.magnitude);
            
            if (_player.transform.position.x < gameObject.transform.position.x)
            {
                _rigidbody2D.velocity = new Vector2(- _speed, 0);
                _isFacingRight = true;
            }
            else if (_player.transform.position.x > gameObject.transform.position.x)
            {
                _rigidbody2D.velocity = new Vector2(_speed, 0);
                _isFacingRight = false;
            }
        }

        private void Jump()
        {
            _rigidbody2D.AddForce(Vector2.up * _enemyConfig.JumpForce  ,ForceMode2D.Impulse);
        }

        public void Stay(bool value)
        {
            _stopWalk = value;
        }
        
        private void FlipX()
        {
            if (_isFacingRight)
            {
                Vector3 localScale = transform.localScale;
                localScale.x = -1f;
                transform.localScale = localScale;
            }
            else
            {
                Vector3 localScale = transform.localScale;
                localScale.x = 1f;
                transform.localScale = localScale;
            }
        }
    }
}