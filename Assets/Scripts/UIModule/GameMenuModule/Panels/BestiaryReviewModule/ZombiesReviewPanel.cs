using System;
using Infrastructure;
using UnityEngine;

namespace UIModule.MainMenuModule
{
    public class ZombiesReviewPanel : ReviewPanel
    {
        [SerializeField] private ZombiesInfoPanel _zombiesInfoPanel;
        
        public void Initialize(Action OnReturnButtonClick, Action OnSwitchButtonClick)
        {
            base.Initialize(OnReturnButtonClick, OnSwitchButtonClick);
            for (int i = 0; i < _charactersButtons.Length; i++)
            {
                ((ZombieButton)_charactersButtons[i]).Initialize(zombieType => _zombiesInfoPanel.UpdateInfoPanel(ObjectLoader.LoadZombieSO(zombieType)));
            }
            _zombiesInfoPanel.UpdateInfoPanel(ObjectLoader.LoadZombieSO(((ZombieButton)_charactersButtons[0]).ZombieType));
        }
    }
}