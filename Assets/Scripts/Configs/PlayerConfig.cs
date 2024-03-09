using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public sealed class PlayerConfig : ScriptableObject
    {
        public float MovingTresh { get => 0.1F; } // no touch!
        
        [Header("Характеристики персонажа")]

        [SerializeField] private int _health = 3;
        [SerializeField] private int _maxHealth = 10;
        [SerializeField] private int _damage = 1;
        [SerializeField] private int _walkSpeed = 10;
        [SerializeField] private int _jumpForce = 10;

        [Header("Звуки персонажа")] 
        [SerializeField] private AudioClip _jumpAudioClip;
        [SerializeField] private AudioClip _fallingAudioClip;
        [SerializeField] private AudioClip _runAudioClip;

        public int Health => _health;
        public int MaxHealth => _maxHealth;
        public int Damage => _damage;
        public int WalkSpeed => _walkSpeed;
        public int JumpForce => _jumpForce;
        public AudioClip JumpAudioClip => _jumpAudioClip;
        public AudioClip FalAudioClip => _fallingAudioClip;
        public AudioClip RuAudioClip => _jumpAudioClip;
    }
}