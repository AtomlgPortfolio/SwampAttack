using System.Collections.Generic;
using Game.Player;
using Game.UI.Weapons;
using Game.Weapons;
using UnityEngine;

namespace Game.UI.Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private WeaponView _weaponView;
        [SerializeField] private GameObject _itemsContainer;
        
        private PlayerWallet _playerWallet;
        private PlayerWeapons _playerWeapons;

        private readonly List<WeaponView> _weaponViews = new List<WeaponView>();

        private void OnEnable()
        {
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }

        private void OnDisable()
        {
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
            _playerWallet.MoneyChanged -= ChangeWeaponsStatus;
        }

        private void OnPlayerSpawned(GameObject player)
        {
            _playerWallet = player.GetComponent<PlayerWallet>();
            _playerWeapons = player.GetComponent<PlayerWeapons>();
            _playerWallet.MoneyChanged += ChangeWeaponsStatus;
        }

        private void ChangeWeaponsStatus(int money)
        {
            foreach (WeaponView weapon in _weaponViews) 
                weapon.CheckWeaponStatus(money);
        }

        private void Start()
        {
            foreach (Weapon weapon in _weapons)
            {
                weapon.Construct();
                AddItem(weapon);
            }
        }

        private void AddItem(Weapon weapon)
        {
            WeaponView view = Instantiate(_weaponView, _itemsContainer.transform);
            view.Render(weapon);
            view.SellButtonClick += SellWeapon;
            _weaponViews.Add(view);
        }
        

        private void SellWeapon(Weapon weapon, WeaponView view)
        {
            _playerWeapons.BuyWeapon(weapon);
            view.SellButtonClick -= SellWeapon;
        }
    }
}