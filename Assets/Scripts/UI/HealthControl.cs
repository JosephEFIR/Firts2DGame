using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace First2DGame
{
    public class HealthControl
    {
        private HealthUIView _healthUIView;

        public HealthControl(HealthUIView healthUIView)
        {
            _healthUIView = healthUIView;
            EventManager._onTakeDamageUI += TakeDamage;
        }

        private void TakeDamage()
        {
            var lastHeart = _healthUIView.Hearts.Last();
            lastHeart.gameObject.SetActive(false);
            _healthUIView.Hearts.Remove(lastHeart);
        }
    }
}