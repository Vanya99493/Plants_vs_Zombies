using System;

namespace LevelModule
{
    public class CoinsHolder
    {
        public event Action<int> ChangeCoinsEvent;

        public int Coins { get; private set; }

        public CoinsHolder(int startCoinsAmount)
        {
            Coins = startCoinsAmount;
        }
        
        public void AddCoins(int newCoins)
        {
            Coins += newCoins;
            ChangeCoinsEvent?.Invoke(Coins);
        }

        public void WithdrawCoins(int coins)
        {
            if (Coins >= coins)
            {
                Coins -= coins;
                ChangeCoinsEvent?.Invoke(Coins);
            }
        }
    }
}