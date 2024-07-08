using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.LevelModule
{
    public class PauseMenu : BasePanel
    {
        [SerializeField] private Button _resumeGameButton;
        [SerializeField] private Button _restartLevelButton;
        [SerializeField] private Button _exitToMainMenuButton;
        [SerializeField] private ConfirmWindow _confirmWindow;

        public void Initialize(Action OnResumeGameButtonClick,
            Action OnRestartLevelButtonClick,
            Action OnExitToMainMenuButtonClick)
        {
            _confirmWindow.gameObject.SetActive(true);
            _resumeGameButton.onClick.AddListener(() => OnResumeGameButtonClick?.Invoke());
            _restartLevelButton.onClick.AddListener(() =>
            {
                _confirmWindow.ActivatePanel();
                _confirmWindow.Initialize(
                    OnRestartLevelButtonClick, 
                    () => _confirmWindow.DeactivatePanel()
                    );
            });
            _exitToMainMenuButton.onClick.AddListener(() =>
            {
                _confirmWindow.ActivatePanel();
                _confirmWindow.Initialize(
                    OnExitToMainMenuButtonClick, 
                    () => _confirmWindow.DeactivatePanel()
                );
            });
            
            _confirmWindow.DeactivatePanel();
        }
    }
}