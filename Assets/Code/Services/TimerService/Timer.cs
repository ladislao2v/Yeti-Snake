using System;
using System.Collections;
using Code.Services.PauseService;
using UnityEngine;

namespace Code.Services.TimerService
{
    public class Timer : MonoBehaviour, ITimer, IPausable
    {
        [SerializeField] private int _time;

        private bool _isPaused;

        public event Action<float> Ticked;
        public event Action TimeOut;
        public void Start()
        {
            StartCoroutine(Tick());
        }

        private IEnumerator Tick()
        {
            float timer = 0f;
            
            while (timer < _time)
            {
                if(_isPaused == false)
                    timer += Time.deltaTime;
                
                Ticked?.Invoke((float)timer/_time);
                yield return null;
            }
            
            TimeOut?.Invoke();
        }

        public void OnPause()
        {
            _isPaused = true;
        }

        public void OnResume()
        {
            _isPaused = false;
        }
    }
}