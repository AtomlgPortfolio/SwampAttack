using System;

namespace Game.Enemy.StateMachine.Transitions
{
    public class EnemyDyingTransition : EnemyHitTransition
    {
        protected override void OnHealthChanged(float currentHealth)
        {
            if (currentHealth <= 0)
                NeedTransit = true;
        }
    }
}