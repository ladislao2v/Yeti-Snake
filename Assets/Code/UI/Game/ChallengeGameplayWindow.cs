using Code.Services.RecordService;
using Code.Services.TimerService;
using Code.UI.Elements;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.UI.Game
{
    public class ChallengeGameplayWindow : GameplayWindow
    {
        [SerializeField] private ScoreView _recordView;
        [SerializeField] private TimerView _timerView;
        
        private ITimer _timer;
        private IRecordService _recordService;

        public void Construct(IRecordService recordService, ITimer timer)
        {
            _recordService = recordService;
            _timer = timer;
        }

        private void OnEnable()
        {
            Subscribe();
            _timer.Ticked += _timerView.Render;
            _recordView.Render(_recordService.Record);
        }

        private void OnDisable()
        {
            Unsubscribe();
            _timer.Ticked -= _timerView.Render;
        }
    }
}