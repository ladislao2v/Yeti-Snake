using Assets.Code.Services.AudioService;
using Assets.Code.Services.UserService;
using Assets.Code.UI.Elements;
using Code.Services.AudioService;
using Code.Services.InputService;
using Code.Services.LevelService;
using Code.Services.MapService;
using Code.Services.PauseService;
using Code.Services.RecordService;
using Code.Services.SceneLoaderService;
using Code.Services.ScoreService;
using Code.Services.TimerService;
using Code.Snake;
using Code.UI.Game;
using Code.Yeti;
using UnityEngine;

namespace Code
{
    public class LevelBoot : MonoBehaviour
    {
        [Header("Game Type")] 
        [SerializeField] private GameType _gameType;

        [Header("Objects")] 
        [SerializeField] private Timer _timer;
        [SerializeField] private SwipeHandler _swipeHandler;
        [SerializeField] private MapService _mapService;
        [SerializeField] private Snake.Snake _snake;
        [SerializeField] private Body _body;
        [SerializeField] private Yetis _yetis;

        [Header("UI")]
        [SerializeField] private GameplayWindow _gameplayWindow;
        [SerializeField] private PauseWindow _pauseWindow;
        [SerializeField] private SettingsWindow _settingsWindow;
        [SerializeField] private GameOverWindow _gameOverWindow;

        private IInputService _inputService;
        private IScoreService _scoreService;
        private ISceneLoaderService _sceneLoaderService;
        private ILevelService _levelService;
        private IPauseService _pauseService;
        private IRecordService _recordService;
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

            _userService = new UserService();
            _recordService = new RecordService();
            _scoreService = new ScoreService(_recordService, _gameType);
            _sceneLoaderService = new SceneLoaderService();
            _levelService = new LevelService(_sceneLoaderService);
            _pauseService = new PauseService();

            _yetis.Construct(_levelService, _mapService);

            _snake.Construct(_mapService, _scoreService, _yetis);
            _body.Construct(_mapService);
            _inputService = new InputService(_swipeHandler, _snake);
            _inputService.Enable();

            _pauseService.Add(_snake);
            _pauseService.Add(_inputService);
            
            _gameplayWindow.Construct(_scoreService);
            
            if(_gameplayWindow is ChallengeGameplayWindow challengeGameplayWindow)
                challengeGameplayWindow.Construct(_recordService, _timer);
            
            _pauseWindow.Construct(_pauseService, _sceneLoaderService);
            _settingsWindow.Construct(_audioService, _userService, _pauseService);
            _gameOverWindow.Construct(_sceneLoaderService);

            _gameplayWindow.Show();

            if (_gameType == GameType.Challenge)
            {
                _pauseService.Add(_timer);
                _timer.Start();   
            }
        }

        private void OnEnable()
        {
            _snake.Died += _gameOverWindow.Show;
            _snake.Died += _inputService.Disable;

            if (_gameType == GameType.Challenge)
                _timer.TimeOut += _snake.Die;
        }

        private void OnDisable()
        {
            _snake.Died -= _gameplayWindow.Show;
            _snake.Died -= _inputService.Disable;
            
            if (_gameType == GameType.Challenge)
                _timer.TimeOut -= _snake.Die;
        }
    }
}