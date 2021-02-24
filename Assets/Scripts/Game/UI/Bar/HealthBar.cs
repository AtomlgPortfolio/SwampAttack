using Game.Player;
using UnityEngine;

namespace Game.UI.Bar
{
    public class HealthBar : Bar
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        private PlayerHealth _playerHealth;

        private void OnEnable()
        {
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }

        private void OnPlayerSpawned(GameObject player)
        {
            _playerHealth = player.GetComponent<PlayerHealth>();   
            _playerHealth.HealthChanged += ValueChanged;
        }

        private void OnDisable()
        {
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
            _playerHealth.HealthChanged -= ValueChanged;
        }
    }
}