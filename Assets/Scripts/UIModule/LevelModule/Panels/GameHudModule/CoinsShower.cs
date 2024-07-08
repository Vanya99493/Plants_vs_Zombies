using TMPro;
using UnityEngine;

namespace UIModule.LevelModule
{
    public class CoinsShower : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;

        public void UpdateCoinsText(int newCoinsAmount)
        {
            _coinsText.text = $"{newCoinsAmount}$";
        }
    }
}