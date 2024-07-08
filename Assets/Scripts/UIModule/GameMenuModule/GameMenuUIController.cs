using System;
using UnityEngine;

namespace UIModule.MainMenuModule
{
    public class GameMenuUIController : MonoBehaviour
    {
        [SerializeField] private MainMenuPanel _mainMenuPanel;
        [SerializeField] private PlantsReviewPanel _plantsReviewPanel;
        [SerializeField] private SettingsPanel _settingsPanel;
        [SerializeField] private SelectDifficultyPanel _selectDifficultyPanel;

        public void InitializeMainMenu(Action OnExitButtonClick)
        {
            _mainMenuPanel.gameObject.SetActive(true);
            _mainMenuPanel.Initialize(
                () => _selectDifficultyPanel.ActivatePanel(),
                () => _plantsReviewPanel.ActivatePanel(),
                () => _settingsPanel.ActivatePanel(),
                OnExitButtonClick);
            _mainMenuPanel.ActivatePanel();
        }

        public void InitializePlantsReviewMenu()
        {
            _plantsReviewPanel.gameObject.SetActive(true);
            _plantsReviewPanel.Initialize(() => _plantsReviewPanel.DeactivatePanel());
            _plantsReviewPanel.DeactivatePanel();
        }

        public void InitializeSettingsMenu(Action<float> OnVolumeChangeAction)
        {
            _settingsPanel.gameObject.SetActive(true);
            _settingsPanel.Initialize(
                () => _settingsPanel.DeactivatePanel(),
                OnVolumeChangeAction
                );
            _settingsPanel.DeactivatePanel();
        }

        public void InitializeSelectDifficultyMenu(Action OnLoadLevelButtonClick, Action<float> OnDifficultySliderChange)
        {
            _selectDifficultyPanel.gameObject.SetActive(true);
            _selectDifficultyPanel.Initialize(
                () => _selectDifficultyPanel.DeactivatePanel(),
                OnLoadLevelButtonClick,
                OnDifficultySliderChange
                );
            _selectDifficultyPanel.DeactivatePanel();
        }
    }
}