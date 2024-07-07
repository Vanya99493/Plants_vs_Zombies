using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class ConfirmWindow : BasePanel
    {
        [SerializeField] private TextMeshProUGUI _textField;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;

        public void Initialize(Action OnConfrimButtonClick,
            Action OnCancelButtonClick,
            string infoText = "Are you sure?")
        {
            _confirmButton.onClick.AddListener(() => OnConfrimButtonClick?.Invoke());
            _cancelButton.onClick.AddListener(() => OnCancelButtonClick?.Invoke());
            _textField.text = infoText;
        }

        private void OnDisable()
        {
            _confirmButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.RemoveAllListeners();
        }
    }
}