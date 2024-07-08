using System;
using LevelModule.CharactersModule;
using ObjectLoaderModule;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    public class PlantButton : CharacterButton
    {
        [SerializeField] private PlantType _plantType;

        public PlantType PlantType => _plantType;

        private void Awake()
        {
            base.Awake();
            if (_plantType == PlantType.None)
            {
                gameObject.SetActive(false);
                return;
            }
            _button.GetComponent<Image>().sprite = ObjectLoader.LoadPlantSO(_plantType).Icon;
        }

        public void Initialize(Action<PlantType> OnButtonClick)
        {
            _button.onClick.AddListener(() => OnButtonClick?.Invoke(_plantType));
        }
    }
}