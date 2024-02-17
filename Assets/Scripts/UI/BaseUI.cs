using UnityEngine;

namespace Scripts.UI
{
    public abstract class BaseUI : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public abstract void Initialize();
        protected abstract void OnDisable();
    }
}