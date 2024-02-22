using System;
using UnityEngine;

namespace Code.Services.InputService
{
    public class SwipeHandler : MonoBehaviour
    {
        private bool _isDragging = false;
        private Vector2 _startTouch;
        private Vector2 _swipeDelta;

        public event Action<Vector3Int> Swiped; 

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDragging = true;
                _startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
                Reset();
            }

            if (Input.touches.Length > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    _isDragging = true;
                    _startTouch = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    _isDragging = false;
                    Reset();
                }
            }
            
            _swipeDelta = Vector2.zero;
            if (_isDragging)
            {
                if (Input.touches.Length > 0)
                    _swipeDelta = Input.touches[0].position - _startTouch;
                else if (Input.GetMouseButton(0))
                    _swipeDelta = (Vector2) Input.mousePosition - _startTouch;
            }

            if (_swipeDelta.magnitude > 125)
            {
                float x = _swipeDelta.x;
                float y = _swipeDelta.y;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x < 0)
                        Swiped?.Invoke(Vector3Int.left);
                    else
                        Swiped?.Invoke(Vector3Int.right);
                }
                else
                {
                    if (y < 0)
                        Swiped?.Invoke(Vector3Int.down);
                    else
                        Swiped?.Invoke(Vector3Int.up);
                }

                Reset();
            }
        }

        private void Reset()
        {
            _startTouch = _swipeDelta = Vector2.zero;
            _isDragging = false;
        }
    }
}