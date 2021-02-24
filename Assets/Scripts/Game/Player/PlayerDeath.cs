using System;
using Game.Player.Animation;
using Game.StaticData;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerHealth))]
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerDeath: MonoBehaviour
    {
        
        [SerializeField] private PlayerStaticData _playerData;

        private float _destroyAfter;
        
        private PlayerHealth _playerHealth;
        private PlayerAnimator _playerAnimator;

        public event Action OnDied;

        private void Awake()
        {
            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerHealth = GetComponent<PlayerHealth>();
        }

        private void Start()
        {
            _destroyAfter = _playerData.DestroyAfter;
        }

        private void OnEnable()
        {
            _playerHealth.HealthChanged += HealthChanged;
        }

        private void OnDestroy()
        {
            _playerHealth.HealthChanged -= HealthChanged;
        }

        private void HealthChanged(float currentHealth, float maxHealth)
        {
            if (currentHealth <= 0)
                Die();
        }

        private void Die()
        {
            OnDied?.Invoke();
            _playerAnimator.PlayDying();
            Destroy(gameObject, _destroyAfter);
        }
    }
}