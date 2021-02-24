using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI.Panels
{
    public class MenuPanel: Panel
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;
        
        private void OnEnable()
        {
            _openButton.onClick.AddListener(CheckActivePanels);
            _closeButton.onClick.AddListener(ClosePanel);
            _restartButton.onClick.AddListener(RestartGame);
            _menuButton.onClick.AddListener(ToMenu);
            _exitButton.onClick.AddListener(ExitGame);
        }
        
        protected void OnDisable()
        {
            _openButton.onClick.RemoveListener(CheckActivePanels);
            _closeButton.onClick.RemoveListener(ClosePanel);
            _restartButton.onClick.RemoveListener(RestartGame);
            _menuButton.onClick.RemoveListener(ToMenu);
            _exitButton.onClick.RemoveListener(ExitGame);
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
    }
}