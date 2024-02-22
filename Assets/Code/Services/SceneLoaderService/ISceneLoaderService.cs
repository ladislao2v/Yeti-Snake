namespace Code.Services.SceneLoaderService
{
    public interface ISceneLoaderService
    {
        void LoadScene(string name);
        void Restart();
    }
}