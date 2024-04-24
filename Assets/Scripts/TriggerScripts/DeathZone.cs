using System.Threading;
using Assets.Scripts.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scripts.TriggerScripts
{
    public class DeathZone : MonoBehaviour
    {
        private IHealthSystem _healthSystem;
        private CancellationTokenSource _token;
        private const int _tick = 1000;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.TryGetComponent(out IHealthSystem healthSystem))
            {
                _healthSystem = healthSystem;
                _token?.Dispose();
                _token = new CancellationTokenSource();
                GetDamageTick().Forget();
            }
        }
        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.TryGetComponent(out IHealthSystem healthSystem))
            {
                StopTick();
            }
        }

        private async UniTaskVoid GetDamageTick()
        {
            while (_token != null)
            {
                _healthSystem.GetDamage(1);
                await UniTask.Delay(_tick, cancellationToken: _token.Token);
            }
        }

        private void StopTick()
        {
            _token?.Cancel();
        }

        private void OnDestroy()
        {
            StopTick();
            _token?.Dispose();
        }
    }
}
