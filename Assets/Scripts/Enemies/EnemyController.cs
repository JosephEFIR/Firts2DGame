using TMPro;
using UnityEngine;

namespace First2DGame
{
    public class EnemyController 
    {
        private EnemyView _enemyView;
        private SpriteAnimator _spriteAnimator;
        private PlayerView _playerView
            ;

        private float _distanceToTarget;
        private bool _isAttack = true;
        private float _cooldown;
        
        public EnemyController(EnemyView enemyView, SpriteAnimator spriteAnimator, PlayerView playerView)
        {
            _enemyView = enemyView;
            _spriteAnimator = spriteAnimator;
            _enemyView = enemyView;
            _playerView = playerView;
            _distanceToTarget = enemyView.AttackDistance;
            _cooldown = _enemyView.Cooldown;
        }
        
        public void FixedUpdate()
        {
            if (_enemyView.GroundCheck.IsGround == true)
            {
                CheckDistanceToTarget();
                if (_distanceToTarget <= _enemyView.AttackDistance  )
                {
                    Attack();
                }
                else if (_distanceToTarget <= _enemyView.VisibleDistance)
                {
                    Pursuit();
                    _cooldown = _enemyView.Cooldown;
                }
            }
        }
        private void CheckDistanceToTarget()
        {
            _distanceToTarget = Vector3.Distance(_playerView.transform.position, _enemyView.transform.position);
        }

        private void Pursuit()
        {
            _spriteAnimator.StartAnimation(_enemyView.SpriteRenderer, Track.Walk, true, _enemyView.AnimationSpeed);

            if (_playerView.transform.position.x < _enemyView.transform.position.x)
            {
                _enemyView.RigidBody2d.velocity = new Vector2(-_enemyView.Speed, 0);
                _enemyView.SpriteRenderer.flipX = true;
            }
            else if (_playerView.transform.position.x > _enemyView.transform.position.x)
            {
                _enemyView.RigidBody2d.velocity = new Vector2(_enemyView.Speed, 0);
                _enemyView.SpriteRenderer.flipX = false;
            }
        }

        private void Attack()
        {
            _spriteAnimator.StartAnimation(_enemyView.SpriteRenderer, Track.Attack, true, _enemyView.AnimationSpeed);

            if (_isAttack)
            {
                _cooldown -= Time.deltaTime;
                if (_cooldown <= 0)
                {
                    
                    _isAttack = false;
                    _playerView.Health -= _enemyView.Damage;
                }
            }
            else if (_isAttack == false)
            {
                _cooldown = _enemyView.Cooldown;
                _isAttack = true;
            }
        }
    }
}