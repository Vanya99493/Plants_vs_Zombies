using System.Collections.Generic;
using CustomClasses;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.LevelModule
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PlantButtonPressIndicator : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _indicatorCanvasGroup;
        [SerializeField] private List<Pair<int, Button>> _buttons;

        private int _pressedButtonIndex = -1;

        private void Awake()
        {
            if(_indicatorCanvasGroup == null)
            {
                _indicatorCanvasGroup = GetComponent<CanvasGroup>();
            }

            DeactivateIndicator();

            foreach(var button in _buttons)
            {
                button.Value.onClick.AddListener(() => OnButtonClick(button.Key));
            }
        }

        public void DeactivateIndicator()
        {
            _pressedButtonIndex = -1;
            _indicatorCanvasGroup.alpha = 0;
        }

        private void OnButtonClick(int index)
        {
            if(_pressedButtonIndex != index)
            {
                ActivateIndicator(index);
            }
            else
            {
                DeactivateIndicator();
            }
        }

        private void ActivateIndicator(int index)
        {
            _pressedButtonIndex = index;
            _indicatorCanvasGroup.transform.position = _buttons[index].Value.transform.position;
            _indicatorCanvasGroup.alpha = 1;
        }
    }
}