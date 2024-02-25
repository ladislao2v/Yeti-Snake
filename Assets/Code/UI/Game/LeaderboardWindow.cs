using Assets.Code.Services.UserService;
using Code.Services.RecordService;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Game
{
    public class LeaderboardWindow : Window
    {
        [SerializeField] private MainWindow _mainWindow;
        [SerializeField] private Leaderboard.Leaderboard _leaderboard;
        [SerializeField] private Button _backButton;

        public void Construct(IRecordService recordService, IUserService userService)
        {
            _leaderboard.Construct(recordService, userService);
        }

        private void OnEnable()
        {
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            Hide();
            _mainWindow.Show();
        }
    }
}