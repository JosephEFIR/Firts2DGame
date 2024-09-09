using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Buttons
{
    public abstract class BaseUIButton : MonoBehaviour
    {
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        protected abstract void OnClick();
    }
}