using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public float MovingTresh { get => 0.1F; } // no touch!
        
        [Header("Характеристики персонажа")] 
        
        [SerializeField] private int _health;
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _damage;
        [SerializeField] private int _walkSpeed;
        [SerializeField] private int _jumpForce;

        public int Health => _health;
        public int MaxHealth => _maxHealth;
        public int Damage => _damage;
        public int WalkSpeed => _walkSpeed;
        public int JumpForce => _jumpForce;
    }
}