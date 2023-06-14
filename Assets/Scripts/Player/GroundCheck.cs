using UnityEngine;

namespace First2DGame
{
    public class GroundCheck : MonoBehaviour
    {
        private bool _isGround;

        public bool IsGround  => _isGround;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground"))
            {
                _isGround = true;
            }

        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            _isGround = false;
        }
    }
}
