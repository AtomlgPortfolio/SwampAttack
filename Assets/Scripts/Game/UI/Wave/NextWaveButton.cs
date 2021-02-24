using Game.Enemy;
using Game.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Wave
{
    public class NextWaveButton : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private EnemySpawner _spawner;
        [SerializeField] private Button _nextWaveButton;
        
        private PlayerDeath _playerDeath;

        private void OnEnable()
        {
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
            _spawner.AllEnemyOnWaySpawned += OnAllEnemyOnAllEnemyOnWaySpawned;
            _nextWaveButton.onClick.AddListener(OnNextButtonClick);
        }

        private void OnPlayerSpawned(GameObject player)
        {
            _playerDeath = player.GetComponent<PlayerDeath>();
            _playerDeath.OnDied += DisableButton;
        }

        private void OnDisable()
        {
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
            _spawner.AllEnemyOnWaySpawned -= OnAllEnemyOnAllEnemyOnWaySpawned;
            _nextWaveButton.onClick.RemoveListener(OnNextButtonClick);
        }

        private void OnNextButtonClick()
        {
            _spawner.NextWave();
            DisableButton();
        }


        private void OnAllEnemyOnAllEnemyOnWaySpawned()
        {
            EnableButton();
        }

        private void EnableButton()
        {
            _nextWaveButton.gameObject.SetActive(true);
        }

        private void DisableButton()
        {
            if (_nextWaveButton.gameObject.activeSelf)
                _nextWaveButton.gameObject.SetActive(false);
        }
    }
}