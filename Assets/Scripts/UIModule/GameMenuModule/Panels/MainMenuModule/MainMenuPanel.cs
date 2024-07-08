﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    public class MainMenuPanel : BasePanel
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _plantsReviewButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitGameButton;
        [SerializeField] private ConfirmWindow _confirmWindow;

        public void Initialize(Action OnGameStartButtonClick, Action OnPlantReviewButtonClick,
            Action OnSettingsButtonClick, Action OnExitGameButtonClick)
        {
            _confirmWindow.gameObject.SetActive(true);
            _startGameButton.onClick.AddListener(() => OnGameStartButtonClick?.Invoke());
            _plantsReviewButton.onClick.AddListener(() => OnPlantReviewButtonClick?.Invoke());
            _settingsButton.onClick.AddListener(() => OnSettingsButtonClick?.Invoke());
            _exitGameButton.onClick.AddListener(() =>
            {
                _confirmWindow.ActivatePanel();
                _confirmWindow.Initialize(
                    () => OnExitGameButtonClick?.Invoke(),
                    () => _confirmWindow.DeactivatePanel()
                    );
            });
            
            _confirmWindow.DeactivatePanel();
        }
    }
}