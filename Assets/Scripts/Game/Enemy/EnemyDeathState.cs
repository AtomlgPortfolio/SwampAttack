using System;
using Game.Enemy.StateMachine;
using Game.StaticData;
using UnityEngine;

namespace Game.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyDeathState : State
    {
        [SerializeField] private ParticleSystem _bloodEffect;
        
        private float _destroyAfter;
        
        private EnemyAnimator _animator;

        public event Action<EnemyDeathState> OnDied;

        private void Awake()
        {
            _animator = GetComponent<EnemyAnimator>();
        }

        private void OnEnable()
        {
            Die();
        }

        public void Construct(EnemyStaticData enemyStaticData)
        {
            _destroyAfter = enemyStaticData.DestroyAfter;
        }

        private void Die()
        {
            PlayEffect();
            PlayAnimation();
            OnDied?.Invoke(this);
            Destroy(gameObject, _destroyAfter);
        }

        private void PlayEffect()
        {
            _bloodEffect.Play();
        }
        
        private void PlayAnimation()
        {
            _animator.PlayDeath();
        }
    }
}