using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class MenuUI : MonoBehaviour
    {
        private const string GameSceneName = "Game";
    
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _exitButton;

        private void OnEnable()
        {
            _newGameButton.onClick.AddListener(StartGame);
            _exitButton.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _newGameButton.onClick.RemoveListener(StartGame);
            _exitButton.onClick.RemoveListener(ExitGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(GameSceneName);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}
