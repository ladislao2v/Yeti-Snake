using System;
using System.Collections;
using UnityEngine;

namespace Code.Services.TimerService
{
    public class Timer : MonoBehaviour, ITimer
    {
        [SerializeField] private int _time;

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
                timer += Time.deltaTime;
                Ticked?.Invoke((float)timer/_time);
                yield return null;
            }
            
            TimeOut?.Invoke();
        }
    }
}