using System;
using Interfaces;
using UnityEngine;

namespace LevelModule
{
    public class Coin : MonoBehaviour, IClickable, IDestroyable
    {
        public event Action<IDestroyable> DestroyEvent;
        public event Action<int> PickUpEvent; 

        public int Coins { get; private set; }

        public void Initialize(int coins)
        {
            Coins = coins;
        }

        public void Click()
        {
            PickUpEvent?.Invoke(Coins);
            Destroy();
        }

        public void Destroy()
        {
            DestroyEvent?.Invoke(this);

            DestroyEvent = null;
            PickUpEvent = null;
        }
    }
}