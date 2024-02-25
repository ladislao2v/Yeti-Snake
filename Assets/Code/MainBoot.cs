using System;
using Assets.Code.Services.AudioService;
using Assets.Code.Services.UserService;
using Assets.Code.UI.Elements;
using Code.Services.AudioService;
using Code.Services.RecordService;
using Code.Services.SceneLoaderService;
using Code.UI.Game;
using UnityEngine;

namespace Code
{
    public class MainBoot : MonoBehaviour
    {
        [SerializeField] private MainWindow _mainWindow;
        [SerializeField] private LevelsWindow _levelsWindow;
        [SerializeField] private SettingsWindow _settingsWindow;
        [SerializeField] private LeaderboardWindow _leaderboardWindow;

        private IRecordService _recordService;
        private ISceneLoaderService _sceneLoaderService;
        private IAudioService _audioService;
        private IUserService _userService;
        
        private void Awake()
        {
            _audioService = new AudioService();

            var providers = FindObjectsOfType<SoundProvider>();

            if (providers.Length > 0)
            {
                foreach (var provider in providers)
                {
                    _audioService.AddSource(provider);
                }
            }

            _sceneLoaderService = new SceneLoaderService();
            _recordService = new RecordService();
            _userService = new UserService();

            _mainWindow.Construct(_sceneLoaderService, _recordService);
            _levelsWindow.Construct(_sceneLoaderService);
            _settingsWindow.Construct(_audioService, _userService);
            _leaderboardWindow.Construct(_recordService, _userService);

            _mainWindow.Show();
        }
    }
}