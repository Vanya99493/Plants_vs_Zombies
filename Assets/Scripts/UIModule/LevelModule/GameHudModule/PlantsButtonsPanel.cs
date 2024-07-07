using System;
using LevelModule;
using LevelModule.CharactersModule;
using UnityEngine;

namespace UIModule.LevelModule
{
    public class PlantsButtonsPanel : MonoBehaviour
    {
        [SerializeField] private PlantButton _sunflowerButton;
        [SerializeField] private PlantButton _peeshooterButton;
        [SerializeField] private PlantButton _wallnutButton;
        
        public void Initialize(Action<PlantType> onPlantButtonClickEvent, 
            CoinsHolder coinsHolder)
        {
            _sunflowerButton.Initialize(onPlantButtonClickEvent);
            _peeshooterButton.Initialize(onPlantButtonClickEvent);
            _wallnutButton.Initialize(onPlantButtonClickEvent);

            coinsHolder.ChangeCoinsEvent += _sunflowerButton.UpdateButton;
            coinsHolder.ChangeCoinsEvent += _peeshooterButton.UpdateButton;
            coinsHolder.ChangeCoinsEvent += _wallnutButton.UpdateButton;

            _sunflowerButton.UpdateButton(coinsHolder.Coins);
            _peeshooterButton.UpdateButton(coinsHolder.Coins);
            _wallnutButton.UpdateButton(coinsHolder.Coins);
        }
    }
}