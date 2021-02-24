using Game.Player;
using Game.StaticData;
using UnityEngine;

namespace Game.Enemy.StateMachine.States
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyAttackState : State
    {
        private float _damage;
        private float _delayBetweenAttack;
        private float _timeAfterLastAttack;
        private bool _isAttacking;
        
        private PlayerHealth _playerHealth;

        public void Construct(PlayerHealth playerHealth, EnemyStaticData enemyData)
        {
            _playerHealth = playerHealth;
            _damage = enemyData.Damage;
            _delayBetweenAttack = enemyData.DelayBetweenAttack;
        }
        
        private void Update()
        {
            if (CanAttack())
            {
                Attack();
                _timeAfterLastAttack = _delayBetweenAttack;
            }

            _timeAfterLastAttack -= Time.deltaTime;
        }

        public override void Exit()
        {
            base.Exit();
            _isAttacking = false;
        }

        private bool CanAttack()
        {
            return _timeAfterLastAttack <= 0 && !_isAttacking;
        }

        private void Attack()
        {
            EnemyAnimator.PlayAttack();
            _playerHealth.TakeDamage(_damage);
            _isAttacking = true;
        }
        
        private void OnAttackAnimationCompleted()
        {
            _isAttacking = false;
        }
    }
}