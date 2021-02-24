using UnityEngine;

namespace Game.Enemy.StateMachine.Transitions
{
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyHitTransition : Transition
    {
        private EnemyHealth _enemyHealth;

        private void Awake()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
        }

        protected void OnEnable()
        {
            _enemyHealth.OnHealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _enemyHealth.OnHealthChanged -= OnHealthChanged;
        }

        protected virtual void OnHealthChanged(float currentHealth)
        {
            if (currentHealth > 0) 
                NeedTransit = true;
        }
    }
}
