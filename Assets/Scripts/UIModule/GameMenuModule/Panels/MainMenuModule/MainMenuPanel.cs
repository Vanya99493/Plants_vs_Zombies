using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    public class MainMenuPanel : BasePanel
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitGameButton;

        public void Initialize(Action OnGameStartButtonClick, 
            Action OnSettingsButtonClick, Action OnExitGameButtonClick)
        {
            _startGameButton.onClick.AddListener(() => OnGameStartButtonClick?.Invoke());
            _settingsButton.onClick.AddListener(() => OnSettingsButtonClick?.Invoke());
            _exitGameButton.onClick.AddListener(() => OnExitGameButtonClick?.Invoke());
        }
    }
}