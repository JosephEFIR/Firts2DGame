using System;

namespace Scripts.Managers
{
    public class EventManager
    {
        public static Action<int> _onTakeDamageUI;
        public static Action _onDeathUI;
        public static Action<int> _onAddHealthUI;

        public void TakeDamageUI(int value)
        {
            if (_onTakeDamageUI != null) { _onTakeDamageUI.Invoke(value);}
        }
        
        public void DeathUI()
        {
            if(_onDeathUI != null) {_onDeathUI.Invoke();}
        }

        public void AddHealthUI(int value)
        {
            if(_onAddHealthUI != null) {_onAddHealthUI.Invoke(value);}
        }
        
    }
}