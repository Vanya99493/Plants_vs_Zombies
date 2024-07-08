using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    public class DifficultyControlPanel : MonoBehaviour
    {
        [SerializeField] private Slider _difficultySlider;
        [SerializeField] private Image _difficultyImage;
        [SerializeField] private Sprite[] _sprites;

        public void Initialize(Action<float> OnDifficultySliderChange)
        {
            _difficultySlider.onValueChanged.AddListener(
                newIndex =>
                {
                    this.OnDifficultySliderChange(newIndex);
                    OnDifficultySliderChange?.Invoke(newIndex);
                });
            this.OnDifficultySliderChange(0);
        }

        private void OnDifficultySliderChange(float newIndex)
        {
            _difficultyImage.sprite = _sprites[(int)newIndex];
        }
    }
}