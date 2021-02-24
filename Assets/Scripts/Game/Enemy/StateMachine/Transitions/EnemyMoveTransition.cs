namespace Game.Enemy.StateMachine.Transitions
{
    public class EnemyMoveTransition : EnemyDistanceTransition
    {
        protected override void Update()
        {
            if (PlayerHealth.IsAlive && !InAttackRange())
                NeedTransit = true;
        }
    }
}