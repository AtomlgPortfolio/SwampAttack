using UnityEngine;

namespace Game.Enemy.StateMachine.Transitions
{
    public class EnemyAttackTransition : EnemyDistanceTransition
    {
        protected override void Update()
        {
            if (PlayerHealth.IsAlive && InAttackRange()) 
                NeedTransit = true;
        }
    }
}