using System.Collections;
using UnityEngine;

namespace First2DGame
{
    public class PlayerManager : MonoBehaviour
    {
        private EventManager _eventManager;
        private PlayerView _playerView;
        private SpriteAnimator _spriteAnimatorPlayer;
        private int _currentPlayerHealth;
        private Reference _reference;

        private bool _isDead;
        private float _timer;
        public PlayerManager(PlayerView playerView, EventManager eventManager, SpriteAnimator spriteAnimator)
        {
            EventManager._onPlayerDeath += Death;
            
            _playerView = playerView;
            _eventManager = eventManager;
            _spriteAnimatorPlayer = spriteAnimator;
            _currentPlayerHealth = _playerView.Health;
            _reference = new Reference();
            _isDead = false;
            _timer = 0.3F;
        }

        public void FixedUpdate()
        {
            if (_currentPlayerHealth != _playerView.Health && _currentPlayerHealth != 0)
            {
                PlayerTakeDamage();
            }
            else if(_currentPlayerHealth <= 0 & _isDead == false)
            {
                _playerView.StopWalk = true;
                _spriteAnimatorPlayer.StartAnimation(_playerView.SpriteRenderer, Track.Death, false,_playerView.AnimationSpeed);
                if (_timer != 0)
                {
                    _timer -= Time.deltaTime;
                    if (_timer <= 0)
                    {
                        _eventManager.PlayerDeath();
                    }
                }
            }
        }
        private void PlayerTakeDamage()
        {
            _eventManager.TakeDamageUI();
            _currentPlayerHealth = _playerView.Health;
        }
        
        private void Death()
        {
            _reference.RestartButton.SetActive(true);
            _isDead = true;
            Time.timeScale = 0;
        }
    }
}