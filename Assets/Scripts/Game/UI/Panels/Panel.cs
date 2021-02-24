using UnityEngine;

namespace Game.UI.Panels
{
    public abstract class Panel : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        private static Panel _currentPanel;

        protected void CheckActivePanels()
        {
            if (_currentPanel == null)
            {
                SetCurrentPanel();
            }
            else
            {
                if (!_currentPanel.Equals(this))
                {
                    _currentPanel.ClosePanel();
                    SetCurrentPanel();
                }
            }
            
            OpenPanel();
            StopTimeScale();
        }

        protected void OpenPanel()
        {
            _panel.gameObject.SetActive(true);
        }

        private void SetCurrentPanel()
        {
            _currentPanel = this;
        }

        protected void ClosePanel()
        {
            _panel.gameObject.SetActive(false);
            StartTimeScale();
        }

        private void StartTimeScale()
        {
            Time.timeScale = 1;
        }

        private void StopTimeScale()
        {
            Time.timeScale = 0;
        }
    }
}