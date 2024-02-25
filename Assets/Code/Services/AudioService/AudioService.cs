using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Services.AudioService
{
    public class AudioService : IAudioService
    {
        private const string AudioKey = nameof(AudioService);

        private readonly List<IAudioSource> _sources = new();
        private readonly int _min = 0;
        private readonly int _max = 1;

        public float Current { get; private set; }

        public AudioService() 
        {
            Current = PlayerPrefs.GetFloat(AudioKey);
        }

        public void AddSource(IAudioSource audioSource)
        {
            if(_sources.Contains(audioSource))
                throw new ArgumentException(nameof(audioSource));

            _sources.Add(audioSource);

            audioSource.ChangeVolume(Current);
        }

        public void ChangeVolume(float value)
        {
            if(value < _min) 
                throw new ArgumentOutOfRangeException(nameof(value));

            if(value > _max)
                throw new ArgumentOutOfRangeException(nameof(value));

            foreach(IAudioSource audioSource in _sources)
                audioSource.ChangeVolume(value);

            Current = value;

            PlayerPrefs.SetFloat(AudioKey, Current);
            PlayerPrefs.Save();
        }
    }
}