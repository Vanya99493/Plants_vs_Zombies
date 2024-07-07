using System;
using UnityEngine;

namespace UIModule.MainMenuModule
{
    public class GameMenuUIController : MonoBehaviour
    {
        [SerializeField] private MainMenuPanel _mainMenuPanel;
        [SerializeField] private SettingsPanel _settingsPanel;
        [SerializeField] private SelectDifficultyPanel _selectDifficultyPanel;

        public void InitializeMainMenu(Action OnExitButtonClick)
        {
            _mainMenuPanel.Initialize(
                () => _selectDifficultyPanel.ActivatePanel(),
                () => _settingsPanel.ActivatePanel(),
                OnExitButtonClick);
            _mainMenuPanel.ActivatePanel();
        }

        public void InitializeSettingsMenu(Action<float> OnVolumeChangeAction)
        {
            _settingsPanel.Initialize(
                () => _settingsPanel.DeactivatePanel(),
                OnVolumeChangeAction
                );
            _settingsPanel.DeactivatePanel();
        }

        public void InitializeSelectDifficultyMenu(Action OnLoadLevelButtonClick, Action<float> OnDifficultySliderChange)
        {
            _selectDifficultyPanel.Initialize(
                () => _selectDifficultyPanel.DeactivatePanel(),
                OnLoadLevelButtonClick,
                OnDifficultySliderChange
                );
            _selectDifficultyPanel.DeactivatePanel();
        }
    }
}