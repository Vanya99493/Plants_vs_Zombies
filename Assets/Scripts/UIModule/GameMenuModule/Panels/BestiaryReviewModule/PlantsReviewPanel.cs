using System;
using Infrastructure;
using Infrastructure.ObjectLoaderModule;
using UnityEngine;

namespace UIModule.MainMenuModule
{
    public class PlantsReviewPanel : ReviewPanel
    {
        [SerializeField] private PlantsInfoPanel _plantsInfoPanel;
        
        public void Initialize(Action OnReturnButtonClick, Action OnSwitchButtonClick)
        {
            base.Initialize(OnReturnButtonClick, OnSwitchButtonClick);
            for (int i = 0; i < _charactersButtons.Length; i++)
            {
                ((PlantButton)_charactersButtons[i]).Initialize(plantType => _plantsInfoPanel.UpdateInfoPanel(ObjectLoader.LoadPlantSO(plantType)));
            }
            _plantsInfoPanel.UpdateInfoPanel(ObjectLoader.LoadPlantSO(((PlantButton)_charactersButtons[0]).PlantType));
        }
    }
}