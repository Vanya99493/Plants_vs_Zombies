using System;
using LevelModule;
using LevelModule.CharactersModule;
using UnityEngine;

namespace UIModule.LevelModule
{
    public class LevelUIController : MonoBehaviour
    {
        [SerializeField] private GameHud _gameHud;

        public void InitializeGameHud(Action<PlantType> OnPlantButtonClickEvent,
            Action OnRemovePlantButtonClickEvent, 
            CoinsHolder coinsHolder)
        {
            _gameHud.Initialize(OnPlantButtonClickEvent, OnRemovePlantButtonClickEvent, coinsHolder);
        }
    }
}