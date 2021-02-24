using UnityEngine;

namespace Game.Enemy
{
    public static class EnemyAnimatorStatesHash
    {
        public static readonly int Idle = Animator.StringToHash("Idle");
        public static readonly int Attack = Animator.StringToHash("Attack");
        public static readonly int Dying = Animator.StringToHash("Dying");
        public static readonly int Moving = Animator.StringToHash("Moving");
        public static readonly int Celebrate = Animator.StringToHash("Celebrate");
        public static readonly int Hit = Animator.StringToHash("Hit");
    }
}