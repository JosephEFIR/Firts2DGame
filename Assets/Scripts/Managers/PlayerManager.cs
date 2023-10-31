using UnityEngine;
using UnityEngine.SceneManagement;

namespace First2DGame
{
    public class PlayerManager : MonoBehaviour
    {
        private EventManager _eventManager;
        private PlayerView _playerView;
        private int _currentPlayerHealth;
        public PlayerManager(PlayerView playerView, EventManager eventManager)
        {
            _playerView = playerView;
            _eventManager = eventManager;
            _currentPlayerHealth = _playerView.Health;
        }

        public void FixedUpdate()
        {
            if (_currentPlayerHealth != _playerView.Health)
            {
                PlayerTakeDamage();
                _currentPlayerHealth = _playerView.Health;
            }
            else if(_currentPlayerHealth <= 0)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(1);
        }

        private void PlayerTakeDamage()
        {
            _eventManager.TakeDamageUI();
        }
    }
}