using System.Collections;
using UnityEngine;

namespace First2DGame
{
    public class DeathZone : MonoBehaviour
    { 
        [SerializeField]private PlayerView _playerView;
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
            if(_playerView.Health != 0)
            {
                _playerView.Health -= 1;  
                yield return new WaitForSeconds(1F);
            }
        }
    }
}
