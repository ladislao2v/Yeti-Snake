using UnityEngine.SceneManagement;

namespace Code.Services.SceneLoaderService
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void Restart()
        {
            var sceneBuildIndex = 
                SceneManager.GetActiveScene().buildIndex;
            
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}