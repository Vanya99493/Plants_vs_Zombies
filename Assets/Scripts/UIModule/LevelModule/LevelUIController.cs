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
    }
}