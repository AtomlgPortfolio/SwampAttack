using System;
using System.Collections;
using Game.Player.Animation;
using Game.StaticData;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private PlayerStaticData _playerData;
        [SerializeField] private ParticleSystem _bloodEffect;
        
        private float _maxHealth;
        private float _currentHealth;

        private IEnumerator _bloodEffectEnumerator;

        private PlayerAnimator _playerAnimator;

        public bool IsAlive => _currentHealth > 0;

        public event Action<float, float> HealthChanged;

        private void Awake()
        {
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void Start()
        {
            SetHealth();
        }

        private void SetHealth()
        {
            _maxHealth = _playerData.Health;
            _currentHealth = _playerData.Health;
        }

        public void TakeDamage(float damage)
        {
            if (_currentHealth > 0)
            {
                _currentHealth -= damage;
                PlayAnimation();
                PlayEffect();
                HealthChanged?.Invoke(_currentHealth, _maxHealth);
            }
        }

        private void PlayEffect()
        {
            _bloodEffect.Play();
        }

        private void PlayAnimation()
        {
            _playerAnimator.PlayHit();
        }

        private void OnHitAnimationCompleted()
        {
            _playerAnimator.PlayIdle();
        }
    }
}