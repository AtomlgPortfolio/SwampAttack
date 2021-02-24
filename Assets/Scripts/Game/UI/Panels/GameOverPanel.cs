using Game.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI.Panels
{
    public class GameOverPanel : Panel
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _exitButton;
        
        private PlayerDeath _playerDeath;
        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _menuButton.onClick.AddListener(ToMenu);
            _exitButton.onClick.AddListener(ExitGame);
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
            _menuButton.onClick.RemoveListener(ToMenu);
            _exitButton.onClick.RemoveListener(ExitGame);
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
            _playerDeath.OnDied -= OpenPanel;
        }

        private void ExitGame()
        {
            ClosePanel();
            Application.Quit();
        }

        private void RestartGame()
        {
            ClosePanel();
            SceneManager.LoadScene(Scenes.GameSceneName);
        }

        private void ToMenu()
        {
            ClosePanel();
            SceneManager.LoadScene(Scenes.MenuSceneName);
        }
        
        private void OnPlayerSpawned(GameObject player)
        {
            _playerDeath = player.GetComponent<PlayerDeath>();
            _playerDeath.OnDied += OpenPanel;
        }
    }
}
