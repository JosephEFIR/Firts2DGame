using System.Collections.Generic;

namespace First2DGame
{
    public class EnemyManager
    {
        private List<EnemyView> _listEnemyViews;
        private SpriteAnimator _spriteAnimator;
        private PlayerView _playerView;

        private List<EnemyController> _listEnemyControllers;
        private EnemyController _enemyController;
        private EnemyView _enemyView;

        public EnemyManager(List<EnemyView> enemyViewList, SpriteAnimator spriteAnimator, PlayerView playerView)
        {
            _listEnemyViews = enemyViewList;
            _spriteAnimator = spriteAnimator;
            _playerView = playerView;
            
            foreach (EnemyController enemyController in  _listEnemyControllers)
            {
                foreach (EnemyView enemyView in _listEnemyViews)
                {
                    AddEnemy(enemyController, enemyView);
                }
            }
        }

        public void FixedUpdate()
        {
             
            
        }

        private void AddEnemy(EnemyController enemyController, EnemyView enemyView)
        {
            _enemyController = enemyController;
            _enemyView = enemyView;
            _enemyController = new EnemyController(_enemyView, _spriteAnimator, _playerView);
        }
    }
}