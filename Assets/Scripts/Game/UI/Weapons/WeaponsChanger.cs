using Game.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Weapons
{
    public class WeaponsChanger : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        
        [SerializeField] private Button _nextWeaponButton;
        [SerializeField] private Button _previousWeaponButton;

        private PlayerWeapons _playerWeapons;

        private void OnEnable()
        {
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }

        private void OnDisable()
        {
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
            _nextWeaponButton.onClick.RemoveListener(_playerWeapons.SelectNext);
            _previousWeaponButton.onClick.RemoveListener(_playerWeapons.SelectPrevious);
        }

        private void OnPlayerSpawned(GameObject player)
        {
            _playerWeapons = player.GetComponent<PlayerWeapons>();
            _nextWeaponButton.onClick.AddListener(_playerWeapons.SelectNext);
            _previousWeaponButton.onClick.AddListener(_playerWeapons.SelectPrevious);
        }
    }
}