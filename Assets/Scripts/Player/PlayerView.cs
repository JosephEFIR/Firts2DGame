using UnityEngine;

namespace First2DGame
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GroundCheck _groundCheck;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Rigidbody2D _rigidbody2d;

        [Header("Настройка физики и анимации")]

        [SerializeField] private float _walkSpeed = 10f;

        [SerializeField] private float _animationSpeed = 3f;

        [SerializeField] private float _jumpForce = 2f;

        [SerializeField] private float _movingTresh = 0.1f;

        [Header("Настройки персонажа")]

        [SerializeField] private int _health = 3;

        [SerializeField] private int _damage = 1;
        
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public float WalkSpeed => _walkSpeed;

        public float AnimationSpeed => _animationSpeed;

        public float JumpForce => _jumpForce;

        public float MovingTresh => _movingTresh;

        public Rigidbody2D Rigidbody2d => _rigidbody2d;

        public int Health { get => _health; set => _health = value; }

        public int Damage => _damage;
        public GroundCheck GroundCheck => _groundCheck;
    }
}