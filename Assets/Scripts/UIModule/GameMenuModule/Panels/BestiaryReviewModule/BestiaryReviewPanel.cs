using System;
using UnityEngine;

namespace UIModule.MainMenuModule
{
    public class BestiaryReviewPanel : BasePanel
    {
        [SerializeField] private PlantsReviewPanel _plantsReviewPanel;
        [SerializeField] private ZombiesReviewPanel _zombiesReviewPanel;

        public void Initialize(Action OnReturnButtonClick)
        {
            _plantsReviewPanel.gameObject.SetActive(true);
            _plantsReviewPanel.ActivatePanel();
            _zombiesReviewPanel.gameObject.SetActive(true);
            _zombiesReviewPanel.DeactivatePanel();
            
            _plantsReviewPanel.Initialize(OnReturnButtonClick, 
                () =>
                {
                    _zombiesReviewPanel.ActivatePanel();
                    _plantsReviewPanel.DeactivatePanel();
                });
            _zombiesReviewPanel.Initialize(OnReturnButtonClick,
                () =>
                {
                    _plantsReviewPanel.ActivatePanel();
                    _zombiesReviewPanel.DeactivatePanel();
                });
        }
    }
}