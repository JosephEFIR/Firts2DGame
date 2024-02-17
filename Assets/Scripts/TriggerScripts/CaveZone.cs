using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Scripts.TriggerScripts
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class CaveZone : MonoBehaviour
    {
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _ForestAudioSource;
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Player")
            {
                _audioSource.DOFade(1F, 3);
                _ForestAudioSource.DOFade(0F, 3);
                _audioSource.Play();

                if (_playerCamera.orthographicSize == 8)
                {
                    StartCoroutine(CameraZoom());
                }
                else
                {
                    StopCoroutine(CameraUnZoom());
                    
                    StartCoroutine(CameraZoom());
                }
            }
        }
        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Player" )
            {
                _audioSource.DOFade(0F, 5);
                _ForestAudioSource.DOFade(1F, 5);
                
                if (_playerCamera.orthographicSize == 4) 
                {
                    StartCoroutine(CameraUnZoom());
                }
                else
                {
                    StopCoroutine(CameraZoom());
                    
                    StartCoroutine(CameraUnZoom());
                }
            }
        }
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
    }
}