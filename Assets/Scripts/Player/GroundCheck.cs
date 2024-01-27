using UnityEngine;

namespace Scripts.Player
{
    public class GroundCheck : MonoBehaviour
    {
        private bool _isGround;

        private void OnTriggerStay2D(Collider2D collision)
        {

            if (collision.gameObject.tag == "Ground")
            {
                _isGround = true;
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                _isGround = false;
            }
        }

        public bool IsGround => _isGround;
    }
}