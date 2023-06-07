using System;
using UnityEngine;

namespace First2DGame
{
    public class PlayerWalker
    {
        private CharacterView _characterView;
        private SpriteAnimator _spriteAnimator;

        private float _yVelocity;

        public PlayerWalker(CharacterView characterView, SpriteAnimator spriteAnimator)
        {
            _characterView = characterView;
            _spriteAnimator = spriteAnimator;
        }
        public void Update()
        {
            var isJump = Input.GetAxis("Vertical") > 0;
            var xAxisInput = Input.GetAxis("Horizontal");

            var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.MovingTresh;

            if (isGoSideWay)
            {
                GoSideWay(xAxisInput);
            }
            if (IsGrounded())
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? Track.Walk : Track.Idle, true, _characterView.AnimationSpeed);

                if (isJump && Mathf.Approximately(_yVelocity, 0))
                {
                    _yVelocity = _characterView.JumpSpeed;

                }
                else if (_yVelocity < 0)
                {
                    _yVelocity = 0;
                    MovementCharacter();
                }
            }
            else
            {
                LandingCharacther();
            }

        }

        private void LandingCharacther()
        {
            _yVelocity += _characterView.Acceleration * Time.deltaTime;
            if(Mathf.Abs(_yVelocity) > _characterView.FlyTresh)
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.Jump, true, _characterView.AnimationSpeed);

                _characterView.transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
        }

        private void MovementCharacter()
        {
            _characterView.transform.position = _characterView.transform.position.Change(y: _characterView.GroundLevel );
        }
        private bool IsGrounded()
        {
            return _characterView.transform.position.y <= _characterView.GroundLevel && _yVelocity <= 0;
        }

        private void GoSideWay(float xAxisInput)
        {
            _characterView.transform.position += Vector3.right * (Time.deltaTime * _characterView.WalkSpeed * (xAxisInput < 0 ? -1 : 1));
            _characterView.SpriteRenderer.flipX = xAxisInput < 0;
        }
    }
}
