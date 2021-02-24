using Game.Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI.Panels
{
    public class GameWonPanel : Panel
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private ParticleSystem[] _saluteEffects;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _menuButton.onClick.AddListener(ToMenu);
            _exitButton.onClick.AddListener(ExitGame);
            _enemySpawner.AllEnemyDied += OnGameIsFinished;
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
            _menuButton.onClick.RemoveListener(ToMenu);
            _exitButton.onClick.RemoveListener(ExitGame);
            _enemySpawner.AllEnemyDied -= OnGameIsFinished;
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

        private void OnGameIsFinished()
        {
            foreach (ParticleSystem salute in _saluteEffects)
                salute.Play();

            OpenPanel();
        }
    }
}