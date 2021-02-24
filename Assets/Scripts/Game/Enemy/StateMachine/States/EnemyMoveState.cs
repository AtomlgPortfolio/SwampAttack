using Game.StaticData;
using UnityEngine;

namespace Game.Enemy.StateMachine.States
{
    public class EnemyMoveState : State
    {
        private float _speed;
        private Transform _target;

        public void Construct(Transform target, EnemyStaticData enemyData)
        {
            _target = target;
            _speed = enemyData.MoveSpeed;
        }

        private void Update()
        {
            transform.position = TargetPosition();
            EnemyAnimator.PlayMove();
        }

        private Vector2 TargetPosition()
        {
            return Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        }
    }
}