using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public sealed class EnemyConfig : ScriptableObject
    {
        public float MovingTresh { get => 0.1F;} // no touch!
        
        [Header("Настройки персонажа")] 
        
        [SerializeField] private int health; 
        [SerializeField] private int _damage;
        [SerializeField] private int _jumpForce;
        [SerializeField] private float _speed;
        [Space]
        [Header("Настройки AI")]
        [SerializeField] private float _visibleDistance;

        public float VisibleDistance => _visibleDistance;

        public int Health { get => health; set => health = value; }
        public int Damage => _damage;
        public int JumpForce => _jumpForce;
        public float Speed => _speed;
    }
}