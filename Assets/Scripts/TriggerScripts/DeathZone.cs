using System.Collections;
using Scripts.Managers;
using UnityEngine;
using Zenject;

namespace Scripts.TriggerScripts
{
    public class DeathZone : MonoBehaviour
    {
        [Inject] private HealthSystem _playerHealthSystem;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Player")
            {
                StartCoroutine(TakeDamageWithTimer());
            }
        }
        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Player")
            {
                StopCoroutine(TakeDamageWithTimer());
            }
        }

        private IEnumerator TakeDamageWithTimer()
        {
            _playerHealthSystem.TakeDamage(1);
            yield return new WaitForSeconds(1F);
        }
    }
}
