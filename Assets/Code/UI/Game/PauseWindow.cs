using Code.Services.PauseService;
using Code.Services.SceneLoaderService;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Game
{
    public class PauseWindow : Window
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _homeButton;
        
        private IPauseService _pauseService;
        private ISceneLoaderService _sceneLoaderService;

        public void Construct(IPauseService pauseService, ISceneLoaderService sceneLoaderService)
        {
            _pauseService = pauseService;
            _sceneLoaderService = sceneLoaderService;
        }

        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(OnResumeButtonClicked);
            _homeButton.onClick.AddListener(OnHomeButtonClicked);
            _pauseService.Pause();
        }

        private void OnDisable()
        {
            _pauseService.Resume();
            _resumeButton.onClick.RemoveListener(OnResumeButtonClicked);
            _homeButton.onClick.RemoveListener(OnHomeButtonClicked);
        }

        private void OnHomeButtonClicked()
        {
            _sceneLoaderService.LoadScene(SceneNames.Main);
        }

        private void OnResumeButtonClicked()
        {
            Hide();
        }
    }
}