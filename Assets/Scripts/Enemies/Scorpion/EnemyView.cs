using UnityEngine;

namespace First2DGame
{
    public class EnemyView : MonoBehaviour
    {

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Rigidbody2D _rigidBody2d;

        [SerializeField] private GroundCheck _groundCheck;
        
        [Header("Настройки AI")]
        [SerializeField] private Transform _target;

        [SerializeField] private float _animationSpeed = 5f;

        [SerializeField] private float _attackDistance = 1;

        [SerializeField] private float _visibleDistance = 5;

        [SerializeField] private float _maxDistancePursuit = 10;

        [SerializeField] private float _movingTresh = 0.1f;

        [Header("Настройки персонажа")]

        [SerializeField] private int _healh = 20;

        [SerializeField] private int _damage = 3;

        [SerializeField] private float _speed = 3;

        [SerializeField] private float _cooldown = 2;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Rigidbody2D RigidBody2d => _rigidBody2d;
            
        public float AnimationSpeed => _animationSpeed;
        public float AttackDistance => _attackDistance;
        public float VisibleDistance => _visibleDistance;
        public float MaxDistancePursuit => _maxDistancePursuit;

        public int Healh { get => _healh; set => _healh = value; }
        public int Damage => _damage;

        public float MovingTresh => _movingTresh;

        public float Speed => _speed;

        public Transform Target { get => _target; set => _target = value; }
        public float Cooldown => _cooldown;
        
        public GroundCheck GroundCheck => _groundCheck;

    }
}