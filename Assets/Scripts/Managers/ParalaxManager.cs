using UnityEngine;

namespace First2DGame
{
    public class ParalaxManager : MonoBehaviour
    {
        private const float Coef = 0.99F;

        private Camera _camera;
        private Transform _backgroundTransform;
        private Vector3 _backgroundStartPosition;
        private Vector3 _cameraStartPosition;


        public ParalaxManager(Camera camera, Transform background)
        {
            _camera = camera;
            _backgroundTransform = background;
            _backgroundStartPosition = background.position;
            _cameraStartPosition = camera.transform.position;
        }

        public void Update()
        {
            _backgroundTransform.position = _backgroundStartPosition + (_camera.transform.position - _cameraStartPosition) * Coef;
        }
    }
}