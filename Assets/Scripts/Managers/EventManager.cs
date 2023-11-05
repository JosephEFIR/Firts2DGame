using System;
using System.Collections;

namespace First2DGame
{
    public class EventManager 
    {
        public static Action _onTakeDamageUI;
        public static Action _onPlayerDeath;
        
        public void TakeDamageUI()
        {
            if (_onTakeDamageUI != null) { _onTakeDamageUI.Invoke();}
        }

        public void PlayerDeath()
        {
            if(_onPlayerDeath != null) {_onPlayerDeath.Invoke();}
        }
    }
}