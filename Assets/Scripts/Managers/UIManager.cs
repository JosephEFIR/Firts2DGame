using Scripts.UI;
using UnityEngine;

namespace Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {

        [SerializeField] private HealthUI _healthUi;
        [SerializeField] private DeathUI _deathUi;

        private void Awake()
        {
            _healthUi.Initialize();
            _deathUi.Initialize();
        }

        private void Start()
        {
            _healthUi.Show();
        }
    }
}