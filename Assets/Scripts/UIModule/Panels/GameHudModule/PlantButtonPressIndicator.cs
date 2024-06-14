using CustomClasses;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.GameHudModule
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PlantButtonPressIndicator : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _indicatorCanvasGroup;
        //[SerializeField] private Pair<int, Button>[] _buttons;
        [SerializeField] private List<Pair<int, Button>> _buttons;

        private int _pressedButtonIndex = -1;

        private void Awake()
        {
            if(_indicatorCanvasGroup == null)
            {
                _indicatorCanvasGroup = GetComponent<CanvasGroup>();
            }

            _indicatorCanvasGroup.alpha = 0;

            foreach(var button in _buttons)
            {
                button.Value.onClick.AddListener(() => OnButtonClick(button.Key));
            }

            /*for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Value.onClick.AddListener(() => OnButtonClick(_buttons[i].Key));
            }*/
        }

        private void OnButtonClick(int index)
        {
            if(_pressedButtonIndex != index)
            {
                _pressedButtonIndex = index;
                _indicatorCanvasGroup.transform.position = _buttons[index].Value.transform.position;
                _indicatorCanvasGroup.alpha = 1;
            }
            else
            {
                _pressedButtonIndex = -1;
                _indicatorCanvasGroup.alpha = 0;
            }
        }
    }
}