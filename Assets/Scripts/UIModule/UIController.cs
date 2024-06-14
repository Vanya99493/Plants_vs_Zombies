using PlantsModule;
using System;
using UIModule.GameHudModule;
using UnityEngine;

namespace UIModule
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameHud _gameHud;

        public void InitializeGameHud(Action<PlantType> OnSunflowerButtonClickEvent,
            Action<PlantType> OnPeeshooterButtonClickEvent,
            Action<PlantType> OnWallnutButtonClickEvent)
        {
            _gameHud.Initialize(OnSunflowerButtonClickEvent, OnPeeshooterButtonClickEvent, OnWallnutButtonClickEvent);
        }
    }
}