using UnityEngine;

namespace Game.StaticData
{
    [CreateAssetMenu(menuName = "Static Data/Create Bullet Static Data", fileName = "BulletData")]
    public class BulletStaticData : ScriptableObject 
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _distance;
        public float Damage => _damage;
        public float Speed => _speed;
        public float Distance => _distance;
    }
}