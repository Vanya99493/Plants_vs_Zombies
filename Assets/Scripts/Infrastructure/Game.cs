using Infrastructure.SceneLoaderModule;
using Infrastructure.SettingsModule;
using UIModule.MainMenuModule;
using UnityEngine;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameMenuUIController _gameMenuUIController;
        [SerializeField] private int _firstLevelSceneIndex = 1;

        private SceneLoader _sceneLoader;
        private int _selectedLevelIndex;
        
        private void Awake()
        {
            _sceneLoader = new SceneLoader();
            
            InitializeUI();
        }

        private void InitializeUI()
        {
            _gameMenuUIController.InitializeMainMenu(OnExitGame);
            _gameMenuUIController.InitializeBestiaryReviewMenu();
            _gameMenuUIController.InitializeSettingsMenu(OnChangeVolume);
            _gameMenuUIController.InitializeSelectDifficultyMenu(OnLoadLevel, OnDifficultyChange);
        }

        private void OnChangeVolume(float newVolume)
        {
            AudioVolumeController.Instance.TryChangeVolume(this, newVolume);
        }

        private void OnLoadLevel()
        {
            _sceneLoader.LoadScene(_selectedLevelIndex + _firstLevelSceneIndex);
        }

        private void OnDifficultyChange(float newDifficultyIndex)
        {
            _selectedLevelIndex = (int)newDifficultyIndex;
        }

        private void OnExitGame()
        {
            Application.Quit();
        }
    }
}