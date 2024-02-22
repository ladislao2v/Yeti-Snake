using System;
using Code.Services.PauseService;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Game
{
    public class SettingsWindow : Window
    {
        [SerializeField] private Button _backButton;
        
        private IPauseService _pauseService;

        public void Construct(IPauseService pauseService)
        {
            _pauseService = pauseService;
        }

        private void OnEnable()
        {
            _backButton.onClick.AddListener(OnBackButtonClicked);
            _pauseService?.Pause();
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveListener(OnBackButtonClicked);
            _pauseService?.Resume();
        }

        private void OnBackButtonClicked()
        {
            Hide();
        }
    }
}