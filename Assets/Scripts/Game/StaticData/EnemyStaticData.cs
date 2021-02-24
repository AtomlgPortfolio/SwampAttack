using UnityEngine;

namespace Game.StaticData
{
    [CreateAssetMenu(menuName = "Static Data/Create Enemy Static Data", fileName = "EnemyData")]
    public class EnemyStaticData : ScriptableObject
    {
        [SerializeField] private EnemyTypeId typeId;
        [SerializeField] private float _health;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _damage;
        [SerializeField] private float delayBetweenAttack;
        [SerializeField] private float transitionRange;
        [SerializeField] private float _rangeSpread;
        [SerializeField] private int _reward;
        [SerializeField] private float _destroyAfter;
        [SerializeField] private GameObject _enemyPrefab;
        
        public EnemyTypeId EnemyTypeId => typeId;
        public float Health => _health;
        public float MoveSpeed => _moveSpeed;
        public float Damage => _damage;
        public float DelayBetweenAttack => delayBetweenAttack;
        public float TransitionRange => transitionRange;
        public float RangeSpread => _rangeSpread;
        public int Reward => _reward;
        public GameObject EnemyPrefab => _enemyPrefab;
        public float DestroyAfter => _destroyAfter;
    }
}