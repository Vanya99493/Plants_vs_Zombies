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
        [SerializeField] private TextMeshProUGUI _mainInfoText;

        protected void UpdateInfoPanel(CharacterSO characterSO)
        {
            _iconImage.sprite = characterSO.Icon;
            _nameText.text = $"Name: {characterSO.Name}";
            _mainInfoText.text = characterSO.GetInfo();
        }
    }
}