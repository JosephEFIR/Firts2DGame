using UnityEngine;

namespace First2DGame
{
    public class PlayerWalker
    {
        private PlayerView _playerView;
        private SpriteAnimator _spriteAnimator;
        private float _xAxisInput;

        public PlayerWalker(PlayerView playerView, SpriteAnimator spriteAnimator)
        {
            _playerView = playerView;
            _spriteAnimator = spriteAnimator;
        }
        public void FixedUpdate()
        {
            var isGoSideWay = Mathf.Abs(_xAxisInput) > _playerView.MovingTresh;
            _xAxisInput = Input.GetAxis("Horizontal");
            if (_playerView.GroundCheck.IsGround)
            {
                _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, isGoSideWay ? Track.Walk : Track.Idle, true, _playerView.AnimationSpeed);
                Move();
                Jump();
            }
            else if (_playerView.GroundCheck.IsGround == false)
            {
                _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, Track.Landing, true, _playerView.AnimationSpeed); ;
                Move();
            }
        }
        private void Move()
        {

            if (Input.GetKey(KeyCode.D))
            {
                _playerView.Rigidbody2d.AddForce(Vector2.right * _playerView.WalkSpeed);
                _playerView.SpriteRenderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _playerView.Rigidbody2d.AddForce(Vector2.left * _playerView.WalkSpeed);
                _playerView.SpriteRenderer.flipX = true;
            }
        }
        private void Jump()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _playerView.Rigidbody2d.AddForce(Vector2.up * _playerView.JumpForce, ForceMode2D.Impulse);
                _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, Track.Jump, true, _playerView.AnimationSpeed);
            }
        }
    }
}