using System.Linq;

namespace First2DGame
{
    public class HealthUIControl
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
            lastHeart.gameObject.SetActive(false);
            _healthUIView.Hearts.Remove(lastHeart);
        }
    }
}