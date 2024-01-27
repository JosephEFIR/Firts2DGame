using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public float MovingTresh { get => 0.1F;} // no touch!
        
        [Header("Настройки персонажа")] 
        
        [SerializeField] private int _healh;
        [SerializeField] private int _damage;
        [SerializeField] private int _jumpForce;
        [SerializeField] private float _speed;
        [SerializeField] private float _cooldown;
        [Space]
        [Header("Настройки AI")]
        
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _visibleDistance;
        [SerializeField] private float _maxDistancePursuit;
        
        public float AttackDistance => _attackDistance;
        public float VisibleDistance => _visibleDistance;
        public float MaxDistancePursuit => _maxDistancePursuit;
        
        public int Healh { get => _healh; set => _healh = value; }
        public int Damage => _damage;
        public int JumpForce => _jumpForce;
        public float Speed => _speed;
        public float Cooldown => _cooldown;
    }
}