using UnityEngine;

namespace Scripts.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GroundCheck _groundCheck;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Rigidbody2D _rigidbody2d;
        
        public GroundCheck GroundCheck => _groundCheck;

        public bool StopWalk{ get; set; }
    }
}