using System;
using Interfaces;
using UnityEngine;

namespace LevelModule
{
    public class Coin : MonoBehaviour, IClickable
    {
        public event Action<int> PickUpEvent; 

        public int Coins { get; private set; }

        public void Initialize(int coins)
        {
            Coins = coins;
        }

        public void Click()
        {
            PickUpEvent?.Invoke(Coins);
            Destroy(gameObject);
        }
    }
}