using System;
using UnityEngine;

namespace Game.Player
{
    public class PlayerWallet : MonoBehaviour
    {
        public int Money { get; private set; }
        public event Action<int> MoneyChanged;
        public void AddMoney(int money)
        {
            Money += money;
            MoneyChanged?.Invoke(Money);
        }

        public void SpendMoney(int weaponPrice)
        {
            Money -= weaponPrice;
            MoneyChanged?.Invoke(Money);
        }
    }
}