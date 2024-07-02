using System;
using LevelModule;
using UnityEngine;

namespace UIModule.LevelModule
{
    public class LevelUIController : MonoBehaviour
    {
        [SerializeField] private GameHud _gameHud;

        public void InitializeGameHud(Action<PlantType> OnSunflowerButtonClickEvent,
            Action<PlantType> OnPeeshooterButtonClickEvent,
            Action<PlantType> OnWallnutButtonClickEvent,
            Action OnRemovePlantButtonClickEvent,
            CoinsHolder coinsHolder)
        {
            _gameHud.Initialize(OnSunflowerButtonClickEvent, OnPeeshooterButtonClickEvent, 
                OnWallnutButtonClickEvent, OnRemovePlantButtonClickEvent, coinsHolder);
        }
    }
}