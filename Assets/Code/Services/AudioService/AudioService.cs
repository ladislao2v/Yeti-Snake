using System;
using System.Collections.Generic;

namespace Code.Services.AudioService
{
    public class AudioService : IAudioService
    {
        private readonly List<IAudioSource> _sources = new();
        private readonly int _min = 0;
        private readonly int _max = 1;

        public void AddSource(IAudioSource audioSource)
        {
            if(_sources.Contains(audioSource))
                throw new ArgumentException(nameof(audioSource));

            _sources.Add(audioSource);
        }

        public void ChangeVolume(int value)
        {
            if(value < _min) 
                throw new ArgumentOutOfRangeException(nameof(value));

            if(value > _max)
                throw new ArgumentOutOfRangeException(nameof(value));

            foreach(IAudioSource audioSource in _sources)
                audioSource.ChangeVolume(value);
        }
    }
}