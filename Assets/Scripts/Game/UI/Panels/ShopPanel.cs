using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Panels
{
    public class ShopPanel : Panel
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;
        
        private void OnEnable()
        {
            _openButton.onClick.AddListener(CheckActivePanels);
            _closeButton.onClick.AddListener(ClosePanel);
        }

        private void OnDisable()
        {
            _openButton.onClick.RemoveListener(CheckActivePanels);
            _closeButton.onClick.RemoveListener(ClosePanel);
        }
    }
}