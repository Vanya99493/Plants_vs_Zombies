using PlantsModule;
using System;
using UnityEngine;

namespace UIModule.GameHudModule
{
    public class GameHud : MonoBehaviour
    {
        [SerializeField] private PlantButton _sunflowerButton;
        [SerializeField] private PlantButton _peeshooterButton;
        [SerializeField] private PlantButton _wallnutButton;

        public void Initialize(Action<PlantType> OnSunflowerButtonClickEvent, 
            Action<PlantType> OnPeeshooterButtonClickEvent, 
            Action<PlantType> OnWallnutButtonClickEvent)
        {
            _sunflowerButton.Initialize(OnSunflowerButtonClickEvent);
            _peeshooterButton.Initialize(OnPeeshooterButtonClickEvent);
            _wallnutButton.Initialize(OnWallnutButtonClickEvent);
        }
    }
}