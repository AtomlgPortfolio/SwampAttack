using System;
using Game.StaticData;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
       private float _currentHealth;

        public bool IsAlive => _currentHealth > 0;
        public event Action<float> OnHealthChanged;
        

        public void Construct(EnemyStaticData enemyData)
        {
            _currentHealth = enemyData.Health;
        }

        public void TakeDamage(float damage)
        {
            if (_currentHealth > 0)
            {
                _currentHealth -= damage;
                OnHealthChanged?.Invoke(_currentHealth);
            }
        }
    }
}