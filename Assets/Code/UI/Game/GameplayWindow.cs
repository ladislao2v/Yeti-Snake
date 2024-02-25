using System;
using Code.Services.ScoreService;
using Code.UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Game
{
    public class GameplayWindow : Window
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private PauseWindow _pauseWindow;
        [SerializeField] private SettingsWindow _settingsWindow;
        
        private IScoreService _scoreService;

        public void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        protected void Subscribe()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonClicked);
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            _scoreService.Changed += _scoreView.Render;
        }

        protected void Unsubscribe()
        {
            _scoreService.Changed -= _scoreView.Render;
            _pauseButton.onClick.RemoveListener(OnPauseButtonClicked);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        }

        private void OnSettingsButtonClicked()
        {
            _settingsWindow.Show();
        }

        private void OnPauseButtonClicked()
        {
            _pauseWindow.Show();
        }
    }
}