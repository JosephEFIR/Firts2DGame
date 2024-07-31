using System;
using AudioObjectLib;
using UnityEngine;

namespace Audio
{
    public class ItemAudio : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip;
        private void Start()
        {
            var audioObject = AudioDataManager.Manager.CreateAudioObject(transform.position, _audioClip);
            audioObject.ApplyEffect();
            audioObject.Play();
        }
    }
}