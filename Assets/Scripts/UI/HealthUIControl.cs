using System.Linq;
using UnityEngine;

namespace First2DGame
{
    public class HealthUIControl : MonoBehaviour
    {
        private HealthUIView _healthUIView;

        public HealthUIControl(HealthUIView healthUIView)
        {
            _healthUIView = healthUIView;
            EventManager._onTakeDamageUI += TakeDamage;
        }

        private void TakeDamage()
        {
            var lastHeart = _healthUIView.Hearts.Last();
            Destroy(lastHeart);
            _healthUIView.Hearts.Remove(lastHeart);
        }
    }
}