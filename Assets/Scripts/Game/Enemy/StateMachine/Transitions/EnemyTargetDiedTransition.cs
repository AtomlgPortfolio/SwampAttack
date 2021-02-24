using Game.Player;

namespace Game.Enemy.StateMachine.Transitions
{
    public class EnemyTargetDiedTransition : Transition
    {
        private PlayerHealth _playerDeath;

        public void Construct(PlayerHealth playerHealth)
        {
            _playerDeath = playerHealth;
        }

        private void Update()
        {
            if (!_playerDeath.IsAlive)
                NeedTransit = true;
        }
    }
}