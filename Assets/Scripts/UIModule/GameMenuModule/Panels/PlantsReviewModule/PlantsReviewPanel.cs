using System;
using ObjectLoaderModule;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    public class PlantsReviewPanel : BasePanel
    {
        [SerializeField] private Button _returnButton;
        [SerializeField] private PlantButton[] _plantButtons;
        [SerializeField] private InfoPanel _infoPanel;

        public void Initialize(Action OnReturnButtonClick)
        {
            _returnButton.onClick.AddListener(() => OnReturnButtonClick?.Invoke());
            for (int i = 0; i < _plantButtons.Length; i++)
            {
                _plantButtons[i].Initialize(plantType => _infoPanel.UpdateInfoPanel(ObjectLoader.LoadPlantSO(plantType)));
            }
            _infoPanel.UpdateInfoPanel(ObjectLoader.LoadPlantSO(_plantButtons[0].PlantType));
        }
    }
}