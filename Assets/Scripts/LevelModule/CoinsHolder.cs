using System;
using UnityEngine;

namespace LevelModule
{
    public class CoinsHolder : MonoBehaviour
    {
        public event Action<int> ChangeCoinsEvent;

        public int Coins { get; private set; }

        public void AddCoins(int newCoins)
        {
            Coins += newCoins;
            ChangeCoinsEvent?.Invoke(Coins);
        }

        public bool WithdrawCoins(int coins)
        {
            if (Coins < coins)
            {
                return false;
            }
            Coins -= coins;
            ChangeCoinsEvent?.Invoke(Coins);
            return true;
        }
    }
}