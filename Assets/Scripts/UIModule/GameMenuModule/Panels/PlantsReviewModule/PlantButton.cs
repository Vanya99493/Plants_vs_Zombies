using System;
using LevelModule.CharactersModule;
using ObjectLoaderModule;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    [RequireComponent(typeof(Button))]
    public class PlantButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private PlantType _plantType;

        public PlantType PlantType => _plantType;
        
        private void Awake()
        {
            _button ??= GetComponent<Button>();
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