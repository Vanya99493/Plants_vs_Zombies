using System;
using LevelModule;
using PlantsModule;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.LevelModule
{
    public class GameHud : MonoBehaviour
    {
        [SerializeField] private PlantsButtonsPanel _plantsButtonsPanel;
        [SerializeField] private Button _removePlantButton;
        [SerializeField] private TextMeshProUGUI _coinsShower;

        public void Initialize(Action<PlantType> onSunflowerButtonClickEvent, 
            Action<PlantType> onPeeshooterButtonClickEvent, 
            Action<PlantType> onWallnutButtonClickEvent,
            Action onRemovePlantButtonClickEvent,
            CoinsHolder coinsHolder)
        {
            _plantsButtonsPanel.Initialize(onSunflowerButtonClickEvent, 
                onPeeshooterButtonClickEvent, 
                onWallnutButtonClickEvent, 
                coinsHolder);
            
            _removePlantButton.onClick.AddListener(() => onRemovePlantButtonClickEvent?.Invoke());
            
            UpdateCoinsShower(coinsHolder.Coins);
            coinsHolder.ChangeCoinsEvent += UpdateCoinsShower;
        }

        private void UpdateCoinsShower(int newCoinsAmount)
        {
            _coinsShower.text = newCoinsAmount.ToString();
        } 
    }
}