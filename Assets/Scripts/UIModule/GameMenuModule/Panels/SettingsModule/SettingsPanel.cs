using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    public class SettingsPanel : BasePanel
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Slider _volumeSlider;

        public void Initialize(Action OnBackButtonClick, Action<float> OnVolumeSliderChange)
        {
            _backButton.onClick.AddListener(() => OnBackButtonClick?.Invoke());
            _volumeSlider.onValueChanged.AddListener(newValue => OnVolumeSliderChange?.Invoke(newValue));
        }
    }
}