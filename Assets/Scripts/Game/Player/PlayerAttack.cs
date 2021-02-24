using Game.Animations;
using Game.Player.Animation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerWeapons))]
    public class PlayerAttack : MonoBehaviour
    {
        private float _timeAfterLastAttack;
        private bool _isAttacking;

        private PlayerAnimator _playerAnimator;
        private PlayerWeapons _playerWeapons;

        private void Awake()
        {
            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerWeapons = GetComponent<PlayerWeapons>();
        }

        private void OnEnable()
        {
            _playerWeapons.Changed += OnWeaponChanged;
            _playerAnimator.StateExited += OnStateExited;
        }

        private void OnStateExited(AnimatorState state)
        {
            if (state == AnimatorState.Attack && _isAttacking)
                _isAttacking = false;
        }

        private void OnDisable()
        {
            _playerWeapons.Changed -= OnWeaponChanged;
        }

        private void OnWeaponChanged()
        {
            if (_isAttacking)
                _isAttacking = false;

            _timeAfterLastAttack = 0;
        }

        private void Update()
        {
            if (AttackButtonDown() && CanAttack())
                Attack();

            _timeAfterLastAttack -= Time.deltaTime;
        }

        private bool AttackButtonDown()
        {
            if (Application.isMobilePlatform)
                return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began &&
                       !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
            
            return Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();
        }

        private void Attack()
        {
            _playerAnimator.PlayAttack();
            _playerWeapons.Current.Attack();
            _timeAfterLastAttack = _playerWeapons.Current.DelayBetweenAttack;
            _isAttacking = true;
        }

        private void OnAttackAnimationCompleted()
        {
            _isAttacking = false;
            _playerAnimator.PlayIdle();
        }

        private bool CanAttack()
        {
            return Time.timeScale > 0 && _timeAfterLastAttack <= 0 && !_isAttacking;
        }
    }
}