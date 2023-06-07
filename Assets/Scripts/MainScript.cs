using UnityEngine;


namespace First2DGame
{
    public class MainScript : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SpriteRenderer _background;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private SpriteAnimConfig _spriteAnimConfig;


        private ParalaxManager _paralax;
        private SpriteAnimator _spriteAnimator;
        private PlayerWalker _playerWalker;

        private void Start()
        {
            _paralax = new ParalaxManager(_camera, _background.transform);
            _spriteAnimator = new SpriteAnimator(_spriteAnimConfig);
            _playerWalker = new PlayerWalker(_characterView, _spriteAnimator);
        }

        private void Update()
        {
            _paralax.Update();
            _spriteAnimator.Update();
            _playerWalker.Update();

        }

        private void FixedUpdate()
        {

        }

        private void OnDestroy()
        {

        }
    }
}