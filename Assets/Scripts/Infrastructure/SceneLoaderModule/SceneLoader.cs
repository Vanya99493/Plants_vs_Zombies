using UnityEngine.SceneManagement;

namespace Infrastructure.SceneLoaderModule
{
    public class SceneLoader
    {
        public void LoadScene(int sceneIndex, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(sceneIndex, loadSceneMode);
        }

        public void LoadScene(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(sceneName, loadSceneMode);
        }
    }
}