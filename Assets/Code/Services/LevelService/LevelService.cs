using Code.Services.SceneLoaderService;

namespace Code.Services.LevelService
{
    public class LevelService : ILevelService
    {
        private readonly ISceneLoaderService _sceneLoaderService;

        public LevelService(ISceneLoaderService sceneLoaderServiceService)
        {
            _sceneLoaderService = sceneLoaderServiceService;
        }
        
        public void EndLevel()
        {
            _sceneLoaderService.LoadScene(SceneNames.Main);
        }
    }
}