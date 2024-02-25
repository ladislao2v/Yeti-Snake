using System;
using UnityEngine;

namespace Code.Services.InputService
{
    public class InputService : IInputService
    {
        private readonly SwipeHandler _swipeHandler;
        private readonly Snake.Snake _snake;

        public InputService(SwipeHandler swipeHandler, Snake.Snake snake)
        {
            _swipeHandler = swipeHandler;
            _snake = snake;
        }
        
        public void Enable()
        {
            _swipeHandler.Swiped += _snake.Move;
        }

        public void Disable()
        {
            _swipeHandler.Swiped -= _snake.Move;
        }

        public void OnPause()
        {
            Disable();
        }

        public void OnResume()
        {
            Enable();
        }
    }
}