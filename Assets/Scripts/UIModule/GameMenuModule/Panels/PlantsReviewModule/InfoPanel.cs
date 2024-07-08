using LevelModule.CharactersModule;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private TextMeshProUGUI _mainInfoText;

        public void UpdateInfoPanel(PlantSO plantSO)
        {
            _iconImage.sprite = plantSO.Icon;
            _nameText.text = $"Name: {plantSO.Name}";
            _priceText.text = $"Price: {plantSO.Price.ToString()}";
            _mainInfoText.text = plantSO.GetInfo();
        }
    }
}