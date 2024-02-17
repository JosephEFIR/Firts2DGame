using Scripts.Enums;
using UnityEngine;

namespace First2DGame.Audio
{
    [RequireComponent(typeof(AudioSource))]
    
    public class GlobalAudioSystem : MonoBehaviour
    {
        [SerializeField] private AudioSource _forestAudio;
        [SerializeField] private AudioSource _caveAudio;
        [SerializeField] private AudioSource _musicAudio;
     

        public void Play(EClipType type ,float smoothTransitionTime = 5)
        {
            switch (type)
            {
                case EClipType.None:
                    Debug.LogWarning("АудиоКлип не выбран");
                    break;
                case EClipType.Forest:
                    break;
                case EClipType.Cave:
                    break;
                case EClipType.Music:
                    break;
            }
        }
    }
}