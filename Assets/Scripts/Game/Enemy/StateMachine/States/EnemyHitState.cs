using UnityEngine;

namespace Game.Enemy.StateMachine.States
{
    public class EnemyHitState : State
    {
        [SerializeField] private ParticleSystem _bloodEffect;
        public override void Enter()
        {
            enabled = true;
            PlayEffect();
            PlayAnimation();
        }

        private void PlayEffect()
        {
            _bloodEffect.Play();
        }

        private void PlayAnimation()
        {
            EnemyAnimator.PlayHit();
        }

        private void OnHitAnimationCompleted()
        {
            EnableTransitions();
        }
    }
}