using System;
using System.Collections.Generic;
using Game.Animations;
using Game.StaticData;
using UnityEngine;
using AnimatorState = Game.Animations.AnimatorState;

namespace Game.Player.Animation
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerWeapons))]
    public class PlayerAnimator : MonoBehaviour, IAnimationStateReader
    {
        private int _currentIdleAnimation;
        private int _currentAttackAnimation;
        private int _currentDyingAnimation;
        private int _currentHitAnimation;

        private PlayerWeapons _playerWeapons;
        private Animator _animator;

        private readonly Dictionary<WeaponTypeId, Dictionary<AnimatorState, int>> _animations =
            new Dictionary<WeaponTypeId, Dictionary<AnimatorState, int>>()
            {
                [WeaponTypeId.Shotgun] = new Dictionary<AnimatorState, int>()
                {
                    [AnimatorState.Attack] = PlayerAnimatorStatesHash.AttackGun,
                    [AnimatorState.Dying] = PlayerAnimatorStatesHash.DyingGun,
                    [AnimatorState.Idle] = PlayerAnimatorStatesHash.IdleGun,
                    [AnimatorState.Hit] = PlayerAnimatorStatesHash.HitGun
                },
                [WeaponTypeId.Axe] = new Dictionary<AnimatorState, int>()
                {
                    [AnimatorState.Attack] = PlayerAnimatorStatesHash.AttackAxe,
                    [AnimatorState.Dying] = PlayerAnimatorStatesHash.DyingAxe,
                    [AnimatorState.Idle] = PlayerAnimatorStatesHash.IdleAxe,
                    [AnimatorState.Hit] = PlayerAnimatorStatesHash.HitAxe
                }
            };

        private readonly Dictionary<(WeaponTypeId, WeaponTypeId), int> _weaponChangeAnimation =
            new Dictionary<(WeaponTypeId, WeaponTypeId), int>()
            {
                [(WeaponTypeId.Shotgun, WeaponTypeId.Axe)] = PlayerAnimatorStatesHash.ChangeGunToAxe,
                [(WeaponTypeId.Axe, WeaponTypeId.Shotgun)] = PlayerAnimatorStatesHash.ChangeAxeToGun
            };

        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;

        public AnimatorState State { get; private set; }

        private void Awake()
        {
            _playerWeapons = GetComponent<PlayerWeapons>();
            _animator = GetComponent<Animator>();
        }

        public void Construct()
        {
            ChangeAnimations();
        }

        public void EnteredState(int stateHash)
        {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int stateHash)
        {
            State = StateFor(stateHash);
            StateExited?.Invoke(State);
        }

        public void PlayDying()
        {
            _animator.Play(_currentDyingAnimation);
        }

        public void PlayAttack()
        {
            _animator.Play(_currentAttackAnimation);
        }

        public void PlayWeaponChange()
        {
            _animator.Play(WeaponHash());
            ChangeAnimations();
        }

        public void PlayIdle()
        {
            _animator.Play(_currentIdleAnimation);
        }

        public void PlayHit()
        {
            _animator.Play(_currentHitAnimation);
        }

        private void ChangeAnimations()
        {
            Dictionary<AnimatorState, int> state = _animations[_playerWeapons.Current.TypeId];
            _currentIdleAnimation = state[AnimatorState.Idle];
            _currentAttackAnimation = state[AnimatorState.Attack];
            _currentDyingAnimation = state[AnimatorState.Dying];
            _currentHitAnimation = state[AnimatorState.Hit];
        }

        private int WeaponHash()
        {
            return _weaponChangeAnimation[(_playerWeapons.Previous.TypeId, _playerWeapons.Current.TypeId)];
        }

        private static AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            if (stateHash == PlayerAnimatorStatesHash.IdleGun || stateHash == PlayerAnimatorStatesHash.IdleAxe)
                state = AnimatorState.Idle;
            else if (stateHash == PlayerAnimatorStatesHash.AttackGun || stateHash == PlayerAnimatorStatesHash.AttackAxe)
                state = AnimatorState.Attack;
            else if (stateHash == PlayerAnimatorStatesHash.DyingGun || stateHash == PlayerAnimatorStatesHash.DyingAxe)
                state = AnimatorState.Dying;
            else if (stateHash == PlayerAnimatorStatesHash.ChangeAxeToGun ||
                     stateHash == PlayerAnimatorStatesHash.ChangeGunToAxe)
                state = AnimatorState.ChangeWeapon;
            else if (stateHash == PlayerAnimatorStatesHash.HitGun ||
                     stateHash == PlayerAnimatorStatesHash.HitAxe)
                state = AnimatorState.Hit;
            else
                state = AnimatorState.None;

            return state;
        }
    }
}