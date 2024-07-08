using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    public class ReviewPanel : BasePanel
    {
        [SerializeField] private Button _returnButton;
        [SerializeField] private Button _switchButton;
        [SerializeField] protected CharacterButton[] _charactersButtons;

        protected void Initialize(Action OnReturnButtonClick, Action OnSwitchButtonClick)
        {
            _returnButton.onClick.AddListener(() => OnReturnButtonClick?.Invoke());
            _switchButton.onClick.AddListener(() => OnSwitchButtonClick?.Invoke());
        }
    }
}