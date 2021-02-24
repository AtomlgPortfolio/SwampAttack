using UnityEngine;

namespace Game.Enemy
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator: MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayDeath()
        {
            _animator.Play(EnemyAnimatorStatesHash.Dying);
        }

        public void PlayAttack()
        {
            _animator.Play(EnemyAnimatorStatesHash.Attack);
        }

        public void PlayMove()
        {
            _animator.Play(EnemyAnimatorStatesHash.Moving);
        }

        public void PlayCelebration()
        {
            _animator.Play(EnemyAnimatorStatesHash.Celebrate);
        }

        public void PlayHit()
        {
            _animator.Play(EnemyAnimatorStatesHash.Hit);
        }
    }
}