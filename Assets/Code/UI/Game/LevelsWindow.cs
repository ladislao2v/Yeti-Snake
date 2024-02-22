using System.Collections.Generic;
using Code.Services.SceneLoaderService;
using Code.UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Game
{
    public class LevelsWindow : Window
    {
        private const string Level = nameof(Level);

        [SerializeField] private Button _backButton;
        [SerializeField] private MainWindow _mainWindow;
        [SerializeField] private List<LevelButton> _levels;
        
        private ISceneLoaderService _sceneLoaderService;

        public void Construct(ISceneLoaderService sceneLoaderService)
        {
            _sceneLoaderService = sceneLoaderService;
        }

        private void OnEnable()
        {
            for (int i = 0; i < _levels.Count; i++)
            {
                _levels[i].Clicked += OnClicked;
            }
            
            _backButton.onClick.AddListener(OnBackButton);
        }

        private void OnDisable()
        {
            for (int i = 0; i < _levels.Count; i++)
            {
                _levels[i].Clicked -= OnClicked;
            }
            
            _backButton.onClick.RemoveListener(OnBackButton);
        }

        private void OnBackButton()
        {
            Hide();
            _mainWindow.Show();
        }

        private void OnClicked(LevelButton button)
        {
            _sceneLoaderService.LoadScene(Level + button.LevelIndex);
        }
    }
}