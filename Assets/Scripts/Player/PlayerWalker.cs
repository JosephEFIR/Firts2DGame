using Unity.VisualScripting;
using UnityEngine;

namespace First2DGame
{
    public class PlayerWalker 
    {
        private CharacterView _characterView;
        private SpriteAnimator _spriteAnimator;
        private float _xAxisInput;
   
        public PlayerWalker(CharacterView characterView, SpriteAnimator spriteAnimator)
        {
            _characterView = characterView;
            _spriteAnimator = spriteAnimator;
            
        }
        public void FixedUpdate(GroundCheck groundCheck)
        {
            var isGoSideWay = Mathf.Abs(_xAxisInput) > _characterView.MovingTresh;
            _xAxisInput = Input.GetAxis("Horizontal");
            if (groundCheck.IsGround)
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? Track.Walk : Track.Idle, true, _characterView.AnimationSpeed);
                Move();
                Jump();
            }
            else
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.Landing , true, _characterView.AnimationSpeed); ;
                Move();
            }
        }
        private void Move()
        {
            
            if (Input.GetKey(KeyCode.D))
            {
                _characterView.Rigidbody2d.AddForce(Vector2.right * _characterView.WalkSpeed);
                _characterView.SpriteRenderer.flipX = false;


            }
            else if (Input.GetKey(KeyCode.A))
            {
                _characterView.Rigidbody2d.AddForce(Vector2.left * _characterView.WalkSpeed);
                _characterView.SpriteRenderer.flipX = true;
                

            }
        }
        private void Jump()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _characterView.Rigidbody2d.AddForce(Vector2.up * _characterView.JumpForce, ForceMode2D.Impulse);
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.Jump, true, _characterView.AnimationSpeed);
            }
        }
    }
}
