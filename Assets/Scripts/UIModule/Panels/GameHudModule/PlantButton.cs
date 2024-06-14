using PlantsModule;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.GameHudModule
{
    [RequireComponent(typeof(Button))]
    public class PlantButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private PlantType _plantType = PlantType.None;

        private void Awake()
        {
            if(_button == null)
            {
                _button = GetComponent<Button>();
            }
        }

        public void Initialize(Action<PlantType> OnButtonClickEvent)
        {
            _button.onClick.AddListener(() => OnButtonClickEvent?.Invoke(_plantType));
        }
    }
}