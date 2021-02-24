using UnityEngine;

namespace Game.StaticData
{
    [CreateAssetMenu(menuName = "Static Data/Create Player Static Data", fileName = "PlayerData")]
    public class PlayerStaticData: ScriptableObject
    {
        [SerializeField] private float _health;
        [SerializeField] private float destroyAfter;
        
        [SerializeField] private GameObject _prefab;

        public float Health => _health;
        public float DestroyAfter => destroyAfter;
        public GameObject Prefab => _prefab;
    }
}