using System;
using Scripts.Configs;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Inject] private PlayerConfig _playerConfig;
        [SerializeField] private GroundCheck _groundCheck;

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private CapsuleCollider2D _colliderSize;

        private float _horizontalAxis;
        private float _verticalAxis;
        private bool _isFacingRight = true;

        private bool _stopWalk = false;

        private Vector2 _defaultColliderSize;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _colliderSize = GetComponent<CapsuleCollider2D>();
            
            _defaultColliderSize = _colliderSize.size;
        }

        private void FixedUpdate()
        {
            if (_stopWalk == false)
            {
                _horizontalAxis = Input.GetAxis("Horizontal");
                
                if (_groundCheck.IsGround)
                {
                    _animator.SetBool("isLanding", false);
                    _animator.SetFloat("Speed", MathF.Abs(_horizontalAxis));
                    
                    if (Input.GetKey(KeyCode.Space))
                    {
                        Run();
                    }
                    else if (Input.GetKey(KeyCode.W))
                    {
                        Jump();
                    }
                    else
                    {
                        Move();
                    }
                }
                else if (_groundCheck.IsGround == false)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        Run();
                    }
                    else
                    {
                        Move();
                        Landing();
                    }
                }
                FlipX();
            }
        }
        private void Move()
        {
            _animator.SetBool("isRun", false);
            _rigidbody2D.velocity = new Vector2(_horizontalAxis * _playerConfig.WalkSpeed, _rigidbody2D.velocity.y);
            
            _colliderSize.size = new Vector2(_defaultColliderSize.x, _defaultColliderSize.y);
        }
        private void Run()
        {
            _animator.SetBool("isLanding", false);
            _animator.SetBool("isJump", false);
            _animator.SetBool("isRun", true);
            _rigidbody2D.velocity = new Vector2(_horizontalAxis * _playerConfig.WalkSpeed * 2, _rigidbody2D.velocity.y);
            _colliderSize.size = new Vector2(0.5F, 0.4F);
        }
        
        private void Jump()
        {
            _animator.SetBool("isJump", true);
            _rigidbody2D.AddForce(Vector2.up * _playerConfig.JumpForce, ForceMode2D.Impulse);
        }
        
        private void Landing()
        {
            if (_rigidbody2D.velocity.y < -.1f)
            {
                Move();
                _animator.SetBool("isJump" ,false);
                _animator.SetBool("isLanding", true);
            }
        }
        
        public void Stay(bool value)
        {
            _stopWalk = value;
        }
        
        private void FlipX()
        {
            if (_isFacingRight && _horizontalAxis < 0f || !_isFacingRight && _horizontalAxis > 0f)
            {
                _isFacingRight = !_isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    }
}