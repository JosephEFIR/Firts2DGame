using System;

namespace First2DGame
{
    public class EventManager 
    {
        public static Action _onTakeDamageUI;

        public void TakeDamageUI()
        {
            if (_onTakeDamageUI != null) { _onTakeDamageUI.Invoke(); }
        }
    }
}