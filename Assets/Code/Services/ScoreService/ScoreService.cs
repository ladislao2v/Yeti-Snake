using System;
using Code.Services.RecordService;

namespace Code.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        private readonly IRecordService _recordService;
        private readonly GameType _gameType;

        private int _score;
        
        public event Action<int> Changed;

        public ScoreService(IRecordService recordService, GameType gameType)
        {
            _recordService = recordService;
            _gameType = gameType;
        }
        
        public void AddScore()
        {
            _score++;
            Changed?.Invoke(_score);
            
            if(_gameType == GameType.Challenge)
                _recordService.TryUpdateRecord(_score);
        }
    }
}