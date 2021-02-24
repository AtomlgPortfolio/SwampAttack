using System.Collections.Generic;
using Game.Animations;
using Game.StaticData;
using Game.Weapons;
using UnityEngine;

namespace Game.Player.Animation
{
    public static class PlayerAnimatorStatesHash
    {
        public static readonly int AttackGun = Animator.StringToHash("AttackGun");
        public static readonly int DyingGun = Animator.StringToHash("DyingGun");
        public static readonly int IdleGun = Animator.StringToHash("IdleGun");
        public static readonly int HitGun = Animator.StringToHash("HitGun");
        public static readonly int ChangeGunToAxe = Animator.StringToHash("ChangeGunToAxe");

        public static readonly int AttackAxe = Animator.StringToHash("AttackAxe");
        public static readonly int DyingAxe = Animator.StringToHash("DyingAxe");
        public static readonly int IdleAxe = Animator.StringToHash("IdleAxe");
        public static readonly int HitAxe = Animator.StringToHash("HitAxe");
        public static readonly int ChangeAxeToGun = Animator.StringToHash("ChangeAxeToGun");
    }
}