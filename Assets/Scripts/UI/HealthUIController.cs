using System.Linq;
using UnityEngine;

namespace First2DGame
{
    public class HealthUIController : MonoBehaviour
    {
        private HealthUIView _healthUIView;

        public HealthUIController(HealthUIView healthUIView)
        {
            _healthUIView = healthUIView;
            EventManager._onTakeDamageUI += TakeDamage;
        }

        private void TakeDamage()
        {
            if (_healthUIView.Hearts.Count == 0)
            {
                _healthUIView.Hearts.Clear(); // Без этого Unity не успевает отправить в метод список сердец
            }
            else
            {
                var lastHeart = _healthUIView.Hearts.Last();
                Destroy(lastHeart);
                _healthUIView.Hearts.Remove(lastHeart);
            }
        }
    }
}