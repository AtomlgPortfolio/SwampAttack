using System;
using System.Collections.Generic;
using Game.Player.Animation;
using Game.Weapons;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerWallet))]
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerWeapons : MonoBehaviour
    {
        [SerializeField] private Weapon _current;
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private Transform _parent;

        private int _currentNumber;

        private PlayerAnimator _playerAnimator;
        private PlayerWallet _playerWallet;
        private PlayerHealth _playerHealth;
        
        public Weapon Current => _current;
        public Weapon Previous { get; private set; }
        public event Action Changed;

        private void Awake()
        {
            _playerWallet = GetComponent<PlayerWallet>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _playerHealth = GetComponent<PlayerHealth>();
        }
        

        public void BuyWeapon(Weapon weapon)
        {
            _playerWallet.SpendMoney(weapon.Price);
            Weapon weaponObj = Instantiate(weapon, _parent);
            weaponObj.Construct();
            _weapons.Add(weaponObj);
        }

        public void SelectNext()
        {
            if (!CanChangeWeapon())
                return;

            if (_currentNumber == _weapons.Count - 1)
                _currentNumber = 0;
            else
                _currentNumber++;

            ChangeWeapon();
        }

        public void SelectPrevious()
        {
            if (!CanChangeWeapon())
                return;

            if (_currentNumber == 0)
                _currentNumber = _weapons.Count - 1;
            else
                _currentNumber--;

            ChangeWeapon();
        }

        private void ChangeWeapon()
        {
            Previous = _current;
            _current = _weapons[_currentNumber];
            _playerAnimator.PlayWeaponChange();
        }


        private void OnChanged()
        {
            Changed?.Invoke();
            _playerAnimator.PlayIdle();
        }

        private bool CanChangeWeapon()
        {
            return _weapons.Count >= 2 && _playerHealth.IsAlive;
        }
    }
}