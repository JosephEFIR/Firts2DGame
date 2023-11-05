using UnityEngine;

namespace First2DGame
{
    public class PlayerWalker
    {
        private PlayerView _playerView;
        private SpriteAnimator _spriteAnimator;
        private float _horizontalAxis;
        private float _verticalAxis;
        private bool _isFacingRight = true;

        public PlayerWalker(PlayerView playerView, SpriteAnimator spriteAnimator)
        {
            _playerView = playerView;
            _spriteAnimator = spriteAnimator;
            _playerView.StopWalk = false;
        }
        public void FixedUpdate()
        {
            if (_playerView.StopWalk == false)
            {
                _horizontalAxis = Input.GetAxis("Horizontal");
                if (_playerView.GroundCheck.IsGround)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        Run();
                    }
                    else
                    {
                        Move();
                        Jump();
                    }
                }
                else if (_playerView.GroundCheck.IsGround == false)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        Run();
                    }
                    else
                    {
                        Move();
                        _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, Track.Landing, true, _playerView.AnimationSpeed); 
                    }
                }
                Flip();
            }
            
        }
        private void Move()
        {
            var isGoSideWay = Mathf.Abs(_horizontalAxis) > _playerView.MovingTresh;
            
            _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, isGoSideWay ? Track.Walk : Track.Idle, true, _playerView.AnimationSpeed);
            _playerView.Rigidbody2d.velocity = new Vector2(_horizontalAxis * _playerView.WalkSpeed, _playerView.Rigidbody2d.velocity.y);
        }
        private void Run()
        {
            _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, Track.Run, true, _playerView.AnimationSpeed);
            _playerView.Rigidbody2d.velocity = new Vector2(_horizontalAxis * _playerView.WalkSpeed * 2, _playerView.Rigidbody2d.velocity.y);
        }
        
        private void Jump()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _playerView.Rigidbody2d.AddForce(Vector2.up * _playerView.JumpForce, ForceMode2D.Impulse);
            }
        }
        
        private void Flip()
        {
            if (_isFacingRight && _horizontalAxis < 0f || !_isFacingRight && _horizontalAxis > 0f)
            {
                _isFacingRight = !_isFacingRight;
                Vector3 localScale = _playerView.transform.localScale;
                localScale.x *= -1f;
                _playerView.transform.localScale = localScale;
            }
        }
    }
}