using UnityEngine;

namespace CoinsModule
{
    public class Coin : MonoBehaviour
    {
        public int Coins { get; private set; }

        public void Initialize(int coins)
        {
            Coins = coins;
        }
    }
}