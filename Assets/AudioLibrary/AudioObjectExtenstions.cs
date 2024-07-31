using Unity.VisualScripting;
using UnityEngine;

namespace AudioObjectLib
{
    public static class AudioObjectExtenstions
    {
        public static void Play(this AudioObject audioObject)
        {
            audioObject.GetAudioSource().Play();
        } //TODO REMEMBER THIS

        public static void ApplyEffect(this AudioObject audioObject)
        {
            var getAudioSource = audioObject.GetAudioSource();
            var audioZone = getAudioSource.AddComponent<AudioReverbZone>();
        }
    }
}