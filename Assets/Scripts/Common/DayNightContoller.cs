using DG.Tweening;
using Scripts.Audio;
using Scripts.Enums;
using UnityEngine;

namespace Scripts.Common
{
    public class DayNightContoller : MonoBehaviour
    {
        [SerializeField] private Transform _dayPoint;
        [SerializeField] private Transform _nightPoint;

        private void Update()
        {
            if (transform.position == _dayPoint.position)
            {
                GlobalAudioSystem.Instance.Play(EClipType.Forest);
                NightCycle();
            }
            else if(transform.position == _nightPoint.position)
            {
                GlobalAudioSystem.Instance.Play(EClipType.Music);
                GlobalAudioSystem.Instance.Stop(EClipType.Forest);
                DayCycle();
            }
        }
        public void SetDay()
        {
            gameObject.transform.position = _dayPoint.position;
        }

        public void SetNight()
        {
            gameObject.transform.position = _nightPoint.position;
        }

        private void DayCycle()
        {
            transform.DOMove(_dayPoint.position, 500);
        }

        private void NightCycle()
        {
            transform.DOMove(_nightPoint.position, 500);
        }
        
    }
}