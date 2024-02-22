using System.Collections.Generic;
using Code.Services.Factories;
using Code.Services.MapService;
using UnityEngine;

namespace Code.Snake
{
    [RequireComponent(typeof(Snake))]
    public class Body : MonoBehaviour
    {
        [SerializeField] private SegmentFactory _factory;
        
        private readonly List<Segment> _segments = new();
        
        private Snake _snake;
        private MapService _mapService;

        public void Construct(MapService mapService)
        {
            _mapService = mapService;
        }

        private void Awake()
        {
            _snake = GetComponent<Snake>();
        }

        private void OnEnable()
        {
            _snake.Collected += OnCollected;
            _snake.Moved += OnMoved;
        }

        private void OnDisable()
        {
            _snake.Collected -= OnCollected;
            _snake.Moved -= OnMoved;
        }

        private void OnMoved()
        {
            if(_segments.Count < 1)
                return;

            for (int i = _segments.Count -  1; i >  0; i--)
            {
                _segments[i].MoveTo(_segments[i -  1].Position);
                
                if(_mapService.GetPositionOnGrid(_segments[i].Position) 
                   == _mapService.GetPositionOnGrid(_snake.Position))
                    _snake.Die();
            }

            _segments[0].MoveTo(_snake.Position);
        }

        private void OnCollected()
        {
            Segment segment = 
                _factory.Create(_snake.Position, transform);
            
            _segments.Add(segment);
        }
    }
}