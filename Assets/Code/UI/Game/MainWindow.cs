using Code.Services.RecordService;
using Code.Services.SceneLoaderService;
using Code.UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Game
{
    public class MainWindow : Window
    {
        [SerializeField] private Button _levelButton;
        [SerializeField] private Button _challengeButton;
        [SerializeField] private Button _leaderboardButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private ScoreView _scoreView;

        [Header("Windows")] 
        [SerializeField] private LevelsWindow _levelsWindow;
        [SerializeField] private LeaderboardWindow _leaderboard;
        [SerializeField] private SettingsWindow _settingsWindow;
        private ISceneLoaderService _sceneLoaderService;
        private IRecordService _recordService;

        public void Construct(ISceneLoaderService sceneLoaderService, IRecordService recordService)
        {
            _recordService = recordService;
            _sceneLoaderService = sceneLoaderService;
        }

        private void OnEnable()
        {
            _levelButton.onClick.AddListener(OnLevelButton);
            _challengeButton.onClick.AddListener(OnChallengeButton);
            _leaderboardButton.onClick.AddListener(OnLeaderboardButton);
            _settingsButton.onClick.AddListener(OnSettingsButton);
            _scoreView.Render(_recordService.Record);
        }
        
        private void OnDisable()
        {
            _levelButton.onClick.RemoveListener(OnLevelButton);
            _challengeButton.onClick.RemoveListener(OnChallengeButton);
            _leaderboardButton.onClick.RemoveListener(OnLeaderboardButton);
            _settingsButton.onClick.RemoveListener(OnSettingsButton);
        }

        private void OnSettingsButton()
        {
            Hide();
            _settingsWindow.Show();
        }

        private void OnLeaderboardButton()
        {
            Hide();
            _leaderboard.Show();
        }

        private void OnChallengeButton()
        {
            Hide();
            _sceneLoaderService.LoadScene(SceneNames.Challenge);
        }

        private void OnLevelButton()
        {
            Hide();
            _levelsWindow.Show();
        }
    }
}