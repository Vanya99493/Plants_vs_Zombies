using PlantsModule;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.GameHudModule
{
    public class GameHud : MonoBehaviour
    {
        [SerializeField] private PlantButton _sunflowerButton;
        [SerializeField] private PlantButton _peeshooterButton;
        [SerializeField] private PlantButton _wallnutButton;
        [SerializeField] private Button _removePlantButton;

        public void Initialize(Action<PlantType> OnSunflowerButtonClickEvent, 
            Action<PlantType> OnPeeshooterButtonClickEvent, 
            Action<PlantType> OnWallnutButtonClickEvent,
            Action OnRemovePlantButtonClickEvent)
        {
            _sunflowerButton.Initialize(OnSunflowerButtonClickEvent);
            _peeshooterButton.Initialize(OnPeeshooterButtonClickEvent);
            _wallnutButton.Initialize(OnWallnutButtonClickEvent);
            _removePlantButton.onClick.AddListener(() => OnRemovePlantButtonClickEvent?.Invoke());
        }
    }
}