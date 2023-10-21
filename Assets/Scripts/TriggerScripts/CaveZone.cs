using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace First2DGame
{
    public class CaveZone : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _background;
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private Light2D _sunLight2D;
        private float _alphaChannel;
        
        private void Awake()
        {
            _alphaChannel = _background.color.a;
        }
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Player")
            {
                if (_alphaChannel == 1)
                {
                    StartCoroutine(DowngradeAlphaChannel());
                    StartCoroutine(CameraZoom());
                    StartCoroutine(DowngradeBrightnessLight());
                }
                else
                {
                    StopAllCoroutines();
                    _alphaChannel = 1;
                }
            }
        }
        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Player" )
            {
                if (_alphaChannel == 0)
                {
                    StartCoroutine(IncreaseAlphaChannel());
                    StartCoroutine(CameraUnZoom());
                    StartCoroutine(IncreaseBrightnessLight());
                }
                else
                {
                    StopAllCoroutines();
                    _alphaChannel = 0;
                }
            }
        }

        #region AlphaChannelRoutines
        private IEnumerator DowngradeAlphaChannel()
        {
            while (_alphaChannel != 0 )
            {
                _alphaChannel -= 0.5F;
                if (_alphaChannel < 0)
                {
                    _alphaChannel = 0;
                }
                _background.color = new Color(1, 1, 1, _alphaChannel);
                yield return new WaitForSeconds(0.1F);
            }
        }
        private IEnumerator IncreaseAlphaChannel()
        {
            while (_alphaChannel < 1)
            {
                _alphaChannel += 0.5F;
                if (_alphaChannel > 1)
                {
                    _alphaChannel = 1;
                }
                _background.color = new Color(1, 1, 1, _alphaChannel);
                yield return new WaitForSeconds(0.1F);
            }
        }
        #endregion

        #region CameraRoutines
        private IEnumerator CameraZoom()
        {
            while (_playerCamera.orthographicSize <= 8 & _playerCamera.orthographicSize != 4)
            {
                _playerCamera.orthographicSize -= 0.1F;
                if (_playerCamera.orthographicSize < 4)
                {
                    _playerCamera.orthographicSize = 4;
                }
                yield return new WaitForSeconds(0.005F);
            }
        }
        
        private IEnumerator CameraUnZoom()
        {
            while (_playerCamera.orthographicSize != 8)
            {
                _playerCamera.orthographicSize += 0.1F;
                if (_playerCamera.orthographicSize > 8)
                {
                    _playerCamera.orthographicSize = 8;
                }
                yield return new WaitForSeconds(0.005F);
            }
        }
        #endregion

        #region LightRoutines
        private IEnumerator DowngradeBrightnessLight()
        {
            while (_sunLight2D.intensity <= 1 & _sunLight2D.intensity != 0.1F)
            {
                _sunLight2D.intensity -= 0.1F;
                if (_sunLight2D.intensity <= 0.1F)
                {
                    _sunLight2D.intensity = 0.1F;
                }
                yield return new WaitForSeconds(0.05F);
            }
        }

        private IEnumerator IncreaseBrightnessLight()
        {
            while (_sunLight2D.intensity != 1)
            {
                _sunLight2D.intensity += 0.1F;
                if (_sunLight2D.intensity >= 1)
                {
                    _sunLight2D.intensity = 1;
                }
                yield return new WaitForSeconds(0.05F);
            }
        }
        #endregion
    }
}