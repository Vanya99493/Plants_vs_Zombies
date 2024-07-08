using LevelModule.CharactersModule;
using TMPro;
using UnityEngine;

namespace UIModule.MainMenuModule
{
    public class PlantsInfoPanel : InfoPanel
    {
        [SerializeField] private TextMeshProUGUI _priceText;

        public void UpdateInfoPanel(PlantSO plantSO)
        {
            base.UpdateInfoPanel(plantSO);
            _priceText.text = $"Price: {plantSO.Price.ToString()}";
        }
    }
}