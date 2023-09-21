using UnityEngine;

namespace First2DGame
{
    public class MainScript : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SpriteRenderer _background;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private HealthUIView _healthUIView;
        
        [SerializeField] private SpriteAnimConfig _playerSpriteAnimConfig;
        [SerializeField] private SpriteAnimConfig _enemySpriteAnimConfig;
        

        private ParalaxManager _paralax;
        private SpriteAnimator _spriteAnimatorPlayer;
        private SpriteAnimator _spriteAnimatorEnemy;
        private PlayerWalker _playerWalker;
        private EnemyAI _enemyAI;
        
        private EventManager _eventManager;
        private PlayerManager _playerManager;
        
        private HealthControl _healthControl;
        
        private void Awake()
        {
            _paralax = new ParalaxManager(_camera, _background.transform);
            _spriteAnimatorPlayer = new SpriteAnimator(_playerSpriteAnimConfig);
            _playerWalker = new PlayerWalker(_playerView, _spriteAnimatorPlayer);
            _spriteAnimatorEnemy = new SpriteAnimator(_enemySpriteAnimConfig);
            _enemyAI = new EnemyAI(_enemyView, _spriteAnimatorEnemy, _playerView);

            _eventManager = new EventManager();
            _playerManager = new PlayerManager(_playerView, _eventManager);
            _healthControl = new HealthControl(_healthUIView);
        }


        private void Update()
        {
            _paralax.Update();
            _spriteAnimatorPlayer.Update();
            _spriteAnimatorEnemy.Update();
        }

        private void FixedUpdate()
        {
            _playerWalker.FixedUpdate();
            _enemyAI.FixedUpdate();
            _playerManager.FixedUpdate();
        } 
    }
}