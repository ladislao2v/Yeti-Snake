using System;
using Assets.Code.Services.UserService;
using Assets.Code.UI.Elements;
using Code.Services.AudioService;
using Code.Services.PauseService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Game
{
    public class SettingsWindow : Window
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private AudioSlider _audioSlider;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _backButton;
        
        private IUserService _userService;
        private IPauseService _pauseService;

        public void Construct(IAudioService audioService, IUserService userService, IPauseService pauseService = null)
        {
            _pauseService = pauseService;
            _userService = userService;
            _audioSlider.Construct(audioService);
        }

        private void OnEnable()
        {
            _saveButton.onClick.AddListener(Rename);
            _backButton.onClick.AddListener(OnBackButtonClicked);
            _pauseService?.Pause();
        }


        private void OnDisable()
        {
            _saveButton.onClick.RemoveListener(Rename);
            _backButton.onClick.RemoveListener(OnBackButtonClicked);
            _pauseService?.Resume();
        }

        private void OnBackButtonClicked()
        {
            Hide();
        }
        private void Rename()
        {
            _userService.Rename(_inputField.text);
        }
    }
}