using DG.Tweening;
using Scripts.Audio;
using Scripts.Enums;
using Scripts.Services;
using UnityEngine;
using Zenject;

namespace Scripts.TriggerScripts
{
    public sealed class CaveZone : MonoBehaviour
    {
        [Inject] private DayNightService _dayNightService;
        
        private Camera _playerCamera;
        private float DefaultOrtographSize;
        
        [SerializeField]
        [Range(3, 6)] private int _zoomSize;

        private void Awake()
        {
            _playerCamera = Camera.main;
        }
        
        private void Start()
        {
            DefaultOrtographSize = _playerCamera.orthographicSize;
        }
        
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Player")
            {
                GlobalAudioService.Instance.Stop(EClipType.Forest);
                GlobalAudioService.Instance.Play(EClipType.Cave);

                _playerCamera.DOOrthoSize(_zoomSize, 1);
            }
        }
        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Player" )
            {
                GlobalAudioService.Instance.Stop(EClipType.Cave);
                GlobalAudioService.Instance.Play(EClipType.Forest);
                
                _playerCamera.DOOrthoSize(DefaultOrtographSize, 1);
            }
        }
    }
}