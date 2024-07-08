using System;
using LevelModule;
using LevelModule.CharactersModule;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.LevelModule
{
    public class GameHud : BasePanel
    {
        [SerializeField] private PlantsButtonsPanel _plantsButtonsPanel;
        [SerializeField] private Button _removePlantButton;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private CoinsShower _coinsShower;

        public void Initialize(Action<PlantType> OnPlantButtonClickEvent, 
            Action OnRemovePlantButtonClickEvent,
            Action OnPauseButtonClick,
            CoinsHolder coinsHolder)
        {
            _plantsButtonsPanel.Initialize(OnPlantButtonClickEvent, coinsHolder);
            _removePlantButton.onClick.AddListener(() => OnRemovePlantButtonClickEvent?.Invoke());
            _pauseButton.onClick.AddListener(() => OnPauseButtonClick?.Invoke());
            
            UpdateCoinsShower(coinsHolder.Coins);
            coinsHolder.ChangeCoinsEvent += UpdateCoinsShower;
        }

        private void UpdateCoinsShower(int newCoinsAmount)
        {
            _coinsShower.UpdateCoinsText(newCoinsAmount);
        } 
    }
}