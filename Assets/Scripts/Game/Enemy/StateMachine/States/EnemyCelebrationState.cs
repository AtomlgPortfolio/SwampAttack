using UnityEngine;

namespace Game.Enemy.StateMachine.States
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyCelebrationState : State
    {
        private void OnEnable()
        {
            EnemyAnimator.PlayCelebration();
        }
    }
}