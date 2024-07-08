using System;
using UnityEngine;

namespace UIModule.MainMenuModule
{
    public class GameMenuUIController : MonoBehaviour
    {
        [SerializeField] private MainMenuPanel _mainMenuPanel;
        [SerializeField] private BestiaryReviewPanel _bestiaryReviewPanel;
        [SerializeField] private SettingsPanel _settingsPanel;
        [SerializeField] private SelectDifficultyPanel _selectDifficultyPanel;

        public void InitializeMainMenu(Action OnExitButtonClick)
        {
            _mainMenuPanel.gameObject.SetActive(true);
            _mainMenuPanel.Initialize(
                () => _selectDifficultyPanel.ActivatePanel(),
                () => _bestiaryReviewPanel.ActivatePanel(),
                () => _settingsPanel.ActivatePanel(),
                OnExitButtonClick);
            _mainMenuPanel.ActivatePanel();
        }

        public void InitializeBestiaryReviewMenu()
        {
            _bestiaryReviewPanel.gameObject.SetActive(true);
            _bestiaryReviewPanel.Initialize(() => _bestiaryReviewPanel.DeactivatePanel());
            _bestiaryReviewPanel.DeactivatePanel();
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