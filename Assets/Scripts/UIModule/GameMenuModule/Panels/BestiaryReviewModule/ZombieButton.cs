using System;
using LevelModule.CharactersModule;
using ObjectLoaderModule;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.MainMenuModule
{
    [RequireComponent(typeof(Button))]
    public class ZombieButton : CharacterButton
    {
        [SerializeField] private ZombieType _zombieType;

        public ZombieType ZombieType => _zombieType;
        
        private void Awake()
        {
            base.Awake();
            if (_zombieType == ZombieType.None)
            {
                gameObject.SetActive(false);
                return;
            }
            _button.GetComponent<Image>().sprite = ObjectLoader.LoadZombieSO(ZombieType).Icon;
        }

        public void Initialize(Action<ZombieType> OnButtonClick)
        {
            _button.onClick.AddListener(() => OnButtonClick?.Invoke(ZombieType));
        }
    }
}