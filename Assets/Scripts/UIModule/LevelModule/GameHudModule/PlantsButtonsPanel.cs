using System;
using LevelModule;
using PlantsModule;
using UnityEngine;

namespace UIModule.LevelModule
{
    public class PlantsButtonsPanel : MonoBehaviour
    {
        [SerializeField] private PlantButton _sunflowerButton;
        [SerializeField] private PlantButton _peeshooterButton;
        [SerializeField] private PlantButton _wallnutButton;
        
        public void Initialize(Action<PlantType> OnSunflowerButtonClickEvent, 
            Action<PlantType> OnPeeshooterButtonClickEvent, 
            Action<PlantType> OnWallnutButtonClickEvent,
            CoinsHolder coinsHolder)
        {
            _sunflowerButton.Initialize(OnSunflowerButtonClickEvent);
            _peeshooterButton.Initialize(OnPeeshooterButtonClickEvent);
            _wallnutButton.Initialize(OnWallnutButtonClickEvent);

            coinsHolder.ChangeCoinsEvent += _sunflowerButton.UpdateButton;
            coinsHolder.ChangeCoinsEvent += _peeshooterButton.UpdateButton;
            coinsHolder.ChangeCoinsEvent += _wallnutButton.UpdateButton;

            _sunflowerButton.UpdateButton(coinsHolder.Coins);
            _peeshooterButton.UpdateButton(coinsHolder.Coins);
            _wallnutButton.UpdateButton(coinsHolder.Coins);
        }
    }
}