using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.LevelModule
{
    public class GameOverPanel : BasePanel
    {
        [SerializeField] private TextMeshProUGUI _gameOverText;
        [SerializeField] private Button _restartLevelButton;
        [SerializeField] private Button _exitLevelButton;

        public void Initialize(Action OnRestartButtonClick, Action OnExitButtonClick)
        {
            _restartLevelButton.onClick.AddListener(() => OnRestartButtonClick?.Invoke());
            _exitLevelButton.onClick.AddListener(() => OnExitButtonClick?.Invoke());
        }

        public void UpdateGameOverText(string gameOverText)
        {
            _gameOverText.text = gameOverText;
        }
    }
}