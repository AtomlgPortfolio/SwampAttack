using System;
using Game.Weapons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Weapons
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _sellButton;
        [SerializeField] private Weapon _weapon;

        private bool _unlocked;
        private bool _bought;

        public event Action<Weapon, WeaponView> SellButtonClick;

        private void OnEnable()
        {
            _sellButton.onClick.AddListener(OnSellButtonClick);
        }

        private void OnDisable()
        {
            _sellButton.onClick.RemoveListener(OnSellButtonClick);
        }

        public void Render(Weapon weapon)
        {
            _weapon = weapon;
            _name.text = weapon.TypeId.ToString();
            _price.text = weapon.Price.ToString();
            _icon.sprite = weapon.Icon;
        }

        public void CheckWeaponStatus(int money)
        {
            if(_bought)
                return;
            
            if (!_unlocked) 
                TryUnlockItem(money);
            else
                TryLockItem(money);
        }

        private void TryUnlockItem(int money)
        {
            if (EnoughMoney(money)) 
                UnlockButton();
        }

        private void TryLockItem(int money)
        {
            if (!EnoughMoney(money)) 
                LockButton();
        }

        private void OnSellButtonClick()
        {
            SellButtonClick?.Invoke(_weapon, this);
            LockButton();
            _bought = true;
        }

        private void UnlockButton()
        {
            _sellButton.interactable = true;
            _unlocked = true;
        }

        private void LockButton()
        {
            _sellButton.interactable = false;
            _unlocked = false;
        }

        private bool EnoughMoney(int money)
        {
            return money >= _weapon.Price;
        }
        
    }
}