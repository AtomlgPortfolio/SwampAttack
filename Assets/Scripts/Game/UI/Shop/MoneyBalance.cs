using Game.Player;
using TMPro;
using UnityEngine;

namespace Game.UI.Shop
{
    public class MoneyBalance : MonoBehaviour 
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private TMP_Text _playerMoneyText;
        
        private PlayerWallet _playerWallet;
        
        private void OnEnable()
        {
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }

        private void OnPlayerSpawned(GameObject player)
        {
            _playerWallet = player.GetComponent<PlayerWallet>();
            _playerWallet.MoneyChanged += OnMoneyChanged;
        }

        private void OnDisable()
        {
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
            _playerWallet.MoneyChanged -= OnMoneyChanged;
        }
        

        private void OnMoneyChanged(int money)
        {
            _playerMoneyText.text = money.ToString();
        }
    }
}