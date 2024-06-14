using PlaygroundModule;
using UIModule;
using UnityEngine;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private UIController _uiController;
        [SerializeField] private PlantsSpawnManager _plantsSpawnManager;

        private void Awake()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            _uiController.InitializeGameHud(_plantsSpawnManager.SelectPlantType, _plantsSpawnManager.SelectPlantType, _plantsSpawnManager.SelectPlantType);
        }
    }
}