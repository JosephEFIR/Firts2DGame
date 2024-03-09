using System.Collections;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Scripts.TriggerScripts
{
    public class DeathZone : MonoBehaviour
    {
        private IHealthSystem _healthSystem;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.TryGetComponent(out IHealthSystem _healthSystem))
            {
                StartCoroutine(GetDamageRoutine()); //TODO wtf?
            }
        }
        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.TryGetComponent(out IHealthSystem _healthSystem))
            {
                StopCoroutine(GetDamageRoutine());
            }
        }

        private IEnumerator GetDamageRoutine()
        {
            while (true)
            {
                _healthSystem.GetDamage(1);
                yield return new WaitForSeconds(1F);
            }
        }
    }
}
