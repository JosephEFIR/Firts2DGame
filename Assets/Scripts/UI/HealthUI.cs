using Scripts.Managers;
using UnityEngine;

namespace Scripts.UI
{
    public sealed class HealthUI : BaseUI
    {
        [SerializeField]private GameObject[] Hearts;
        private int _heartsAmount;
        
        public override void Initialize()
        {
            EventManager._onAddHealthUI += AddHealthUI;
            EventManager._onTakeDamageUI += TakeDamageUI;
        }

        protected override void OnDisable()
        {
            EventManager._onAddHealthUI -= AddHealthUI;
            EventManager._onTakeDamageUI -= TakeDamageUI;
        }
        
        private void AddHealthUI(int value)
        {
            for (int i = 0; i < value; i++)
            {
                Hearts[_heartsAmount + i]?.SetActive(true);
            }
            _heartsAmount += value;
        }

        private void TakeDamageUI(int value)
        {
            for (int i = 0; i < value; i++)
            {
                Hearts[_heartsAmount - value]?.SetActive(false);
            }
            _heartsAmount -= value;
        }
    }
}

