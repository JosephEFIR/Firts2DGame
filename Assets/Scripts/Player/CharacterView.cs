using UnityEngine;

namespace First2DGame
{
    public class CharacterView : MonoBehaviour
    {
       
        [Header("Настройки")]

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Rigidbody2D _rigidbody2d;
        
        [SerializeField] private float _walkSpeed = 10f;

        [SerializeField] private float _animationSpeed = 3f;

        [SerializeField] private float _jumpForce = 2f;

        [SerializeField] private float _movingTresh = 0.1f;

        [SerializeField] private float _flyTresh = 0.4f;

        [SerializeField] private float _groundLevel = 0.5f;

        [SerializeField] private float _acceleration = -10f;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public float WalkSpeed => _walkSpeed;

        public float AnimationSpeed => _animationSpeed;

        public float JumpForce => _jumpForce;

        public float MovingTresh => _movingTresh;

        public float FlyTresh => _flyTresh;

        public float GroundLevel => _groundLevel;

        public float Acceleration => _acceleration;

        public Rigidbody2D Rigidbody2d  => _rigidbody2d;
    }
}