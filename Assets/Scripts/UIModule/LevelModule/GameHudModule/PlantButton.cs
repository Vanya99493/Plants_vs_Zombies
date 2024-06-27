using System;
using ObjectLoaderModule;
using PlantsModule;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.LevelModule
{
    [RequireComponent(typeof(Button))]
    public class PlantButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _plantPrice;
        [SerializeField] private PlantType _plantType = PlantType.None;

        private int _price;

        public void Initialize(Action<PlantType> OnButtonClickEvent)
        {
            if(_button == null)
            {
                _button = GetComponent<Button>();
            }
            _button.onClick.AddListener(() => OnButtonClickEvent?.Invoke(_plantType));
            InitializeData();
        }

        public void UpdateButton(int coinsAmount)
        {
            _button.interactable = coinsAmount >= _price;
        }

        private void InitializeData()
        {
            var plantSO = ObjectLoader.LoadPlantSO(_plantType);
            _price = plantSO.Price;
            _plantPrice.text = _price.ToString();
            _button.GetComponent<Image>().sprite = plantSO.Icon;
        }
    }
}