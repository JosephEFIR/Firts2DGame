using Scripts.Health;
using Scripts.Player;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [Inject] private PlayerController _playerController;
        
        [SerializeField] private Slider _slider;
        private PlayerHealth _playerHealth;

        private CompositeDisposable _disposable = new();
        
        private void Awake()
        {
            _playerHealth = _playerController.GetComponent<PlayerHealth>();
        }

        private void Start()
        {
            _playerHealth.CurrentHealth.Subscribe(v=>
            {
                if (v != 0)
                {
                    _slider.value = (float) v / _playerHealth.MaxHealth.Value;
                }
            }).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable?.Clear();
        }
    }
}

