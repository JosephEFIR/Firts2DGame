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

        public static void Pitch(this AudioObject audioObject,float value)
        {
            audioObject.GetAudioSource().pitch = value;
        }

        public static void RandomPitch(this AudioObject audioObject, float min,float max)
        {
            float value = Random.Range(min, max);
            audioObject.GetAudioSource().pitch = value;
        }
    }
}