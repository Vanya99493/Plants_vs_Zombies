using System;
using LevelModule;
using LevelModule.CharactersModule;
using UnityEngine;

namespace UIModule.LevelModule
{
    public class LevelUIController : MonoBehaviour
    {
        [SerializeField] private GameHud _gameHud;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private GameOverPanel _gameOverPanel;

        public void InitializeGameHud(Action<PlantType> OnPlantButtonClickEvent,
            Action OnRemovePlantButtonClickEvent,
            Action OnPauseButtonClickEvent,
            CoinsHolder coinsHolder)
        {
            _gameHud.gameObject.SetActive(true);
            OnPauseButtonClickEvent += _pauseMenu.ActivatePanel;
            _gameHud.Initialize(OnPlantButtonClickEvent, 
                OnRemovePlantButtonClickEvent,
                OnPauseButtonClickEvent, 
                coinsHolder);
            _gameHud.ActivatePanel();
        }

        public void InitializePauseMenu(Action OnResumeGameButtonClick,
            Action OnRestartLevelButtonClick,
            Action OnExitButtonClick)
        {
            _pauseMenu.gameObject.SetActive(true);
            OnResumeGameButtonClick += _pauseMenu.DeactivatePanel;
            _pauseMenu.Initialize(
                OnResumeGameButtonClick,
                OnRestartLevelButtonClick,
                OnExitButtonClick);
            _pauseMenu.DeactivatePanel();
        }

        public void InitializeGameOverPanel(Action OnRestartLevelButtonClick,
            Action OnExitLevelButtonClick)
        {
            _gameOverPanel.gameObject.SetActive(true);
            _gameOverPanel.Initialize(OnRestartLevelButtonClick, OnExitLevelButtonClick);
            _gameOverPanel.DeactivatePanel();
        }

        public void ActivateGameOverPanel(string gameOVerMessage)
        {
            _gameOverPanel.UpdateGameOverText(gameOVerMessage);
            _gameOverPanel.ActivatePanel();
        }
    }
}