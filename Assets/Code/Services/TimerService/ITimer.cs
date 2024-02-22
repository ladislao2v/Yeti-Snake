using System;
using System.Collections.Generic;

namespace Code.Services.TimerService
{
    public interface ITimer
    {
        event Action<float> Ticked;
        event Action TimeOut;

        public void Start();
    }
}