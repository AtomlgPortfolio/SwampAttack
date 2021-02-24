using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Bar
{
    public abstract class Bar : MonoBehaviour
    {
        [SerializeField] protected Slider Slider;

        protected void ValueChanged(float value, float maxValue)
        {
            Slider.value = value / maxValue;
        }
    }
}