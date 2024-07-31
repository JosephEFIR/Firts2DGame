using System;

namespace Scripts.Managers
{
    public class EventManager
    {
        public static event Action<int> _onTakeDamageUI;
        public static event Action<int> _onAddHealthUI;
        public static event Action _onDeathUI;

        public void TakeDamageUI(int value)
        {
            _onTakeDamageUI?.Invoke(value);
        }
        //TODO УДАЛИТЬ
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