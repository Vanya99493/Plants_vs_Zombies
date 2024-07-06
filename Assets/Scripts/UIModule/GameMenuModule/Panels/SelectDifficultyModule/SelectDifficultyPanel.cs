using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    public class SelectDifficultyPanel : BasePanel
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _loadLevelButton;
        [SerializeField] private Slider _difficultySlider;
        [SerializeField] private Image _difficultyImage;
        
        public void Initialize(Action OnBackButtonClick, Action OnLoadLevelButtonClick, 
            Action<float> OnDifficultySliderChange)
        {
            _backButton.onClick.AddListener(() => OnBackButtonClick?.Invoke());
            _loadLevelButton.onClick.AddListener(() => OnLoadLevelButtonClick?.Invoke());
            _difficultySlider.onValueChanged.AddListener(newIndex => OnDifficultySliderChange?.Invoke(newIndex));
        }
    }
}