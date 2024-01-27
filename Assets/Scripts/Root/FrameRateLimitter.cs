using UnityEngine;

namespace Scripts.Root
{
    public class FrameRateLimitter : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }
}