using System;

namespace Scripts.Managers
{
    public class EventManager
    {
        public static Action<int> _onTakeDamageUI;
        public static Action<int> _onAddHealthUI;
        public static Action _onDeathUI;

        public void TakeDamageUI(int value)
        {
            _onTakeDamageUI?.Invoke(value);
        }
        
        public void AddHealthUI(int value)
        {
            _onAddHealthUI?.Invoke(value);
        }
        
        public void DeathUI()
        {
            _onDeathUI?.Invoke();
        }
    }
}