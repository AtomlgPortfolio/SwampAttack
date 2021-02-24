using Game.Player;
using UnityEngine;

namespace Game.Enemy.StateMachine.Transitions
{
    public abstract class EnemyDistanceTransition : Transition
    {
        private float _transitionRange;

        protected PlayerHealth PlayerHealth;

        public void Construct(PlayerHealth playerHealth, float transitionRange)
        {
            PlayerHealth = playerHealth;
            _transitionRange = transitionRange;
        }

        protected abstract void Update();
        
        protected bool InAttackRange()
        {
            return Vector2.Distance(transform.position, PlayerHealth.transform.position) < _transitionRange;
        }
    }
}