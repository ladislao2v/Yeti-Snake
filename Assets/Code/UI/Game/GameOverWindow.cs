using Code.Services.SceneLoaderService;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Game
{
    public class GameOverWindow : Window
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;

        private ISceneLoaderService _sceneLoaderService;

        public void Construct(ISceneLoaderService sceneLoaderService)
        {
            _sceneLoaderService = sceneLoaderService;
        }

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);   
            _homeButton.onClick.AddListener(OnHomeButtonClicked);   
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);   
            _homeButton.onClick.RemoveListener(OnHomeButtonClicked); 
        }

        private void OnRestartButtonClicked()
        {
            _sceneLoaderService.Restart();
        }

        private void OnHomeButtonClicked()
        {
            _sceneLoaderService.LoadScene(SceneNames.Main);
        }
    }
}