using Game.Enemy;
using Game.StaticData;
using UnityEngine;

namespace Game.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletStaticData _bulletData;

        private float _damage;
        private float _speed;
        private float _distance;
        private bool _isDestroyed;
        
        private Vector2 _shootPosition;

        private void Start()
        {
            SetData();
        }

        private void SetData()
        {
            _damage = _bulletData.Damage;
            _speed = _bulletData.Speed;
            _distance = _bulletData.Distance;
            _shootPosition = transform.position;
        }

        private void Update()
        {
            if(_isDestroyed)
                return;;
            
            float distance = Vector2.Distance(_shootPosition, transform.position);
            if (distance > _distance) 
                Destroy();
            else
                Translate();
        }

        private void Translate()
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(_isDestroyed)
                return;
            
            if (other.TryGetComponent(out EnemyHealth enemyHealth))
            {
                if (enemyHealth.IsAlive)
                {
                    enemyHealth.TakeDamage(_damage);
                    Destroy();
                }
            }
        }

        private void Destroy()
        {
            _isDestroyed = true;
            Destroy(gameObject);
        }
    }
}