using System;
using System.Collections;
using Code.Services.MapService;
using Code.Services.PauseService;
using Code.Services.ScoreService;
using Code.Yeti;
using UnityEngine;

namespace Code.Snake
{
    public class Snake : MonoBehaviour, IMovable, IPausable
    {
        [SerializeField] private float _delay = 2f;
        [SerializeField] private Transform _head;

        private IMapService _mapService;
        private IScoreService _scoreService;
        private Coroutine _moving;
        private Vector3Int _currentDirection;
        private Yetis _yetis;
        private bool _isPaused;

        public Vector3 Position => _head.position;

        public event Action Collected;
        public event Action Moved;
        public event Action Died;

        public void Construct(IMapService mapService, IScoreService scoreService, Yetis yetis)
        {
            _yetis = yetis;
            _scoreService = scoreService;
            _mapService = mapService;
            
            Move(Vector3Int.up);
        }

        public void Move(Vector3Int direction)
        {
            if(_isPaused == false && _currentDirection == direction)
                return;
            
            if(_moving != null)
                StopCoroutine(_moving);

            _moving = StartCoroutine(Moving(direction));
        }

        public void Collect()
        {
            Collected?.Invoke();
            _scoreService.AddScore();
        }

        public void Die()
        {
            Died?.Invoke();
            gameObject.SetActive(false);
        }

        private IEnumerator Moving(Vector3Int direction)
        {
            _currentDirection = direction;
            
            while (true)
            {
                _head.position = (_mapService.ConvertToGridCell(_head.position, direction));
                
                if(_yetis.IsIntersect(_mapService.GetPositionOnGrid(Position)))
                    Collect();
                
                yield return new WaitForSeconds(_delay);

                Moved?.Invoke();
            }
        }

        public void OnPause()
        {
            StopCoroutine(_moving);
            _isPaused = true;
        }

        public void OnResume()
        {
            Move(_currentDirection);
            _isPaused = false;
        }
    }
}
