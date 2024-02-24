using Code.Services.AudioService;
using System;
using UnityEngine;

namespace Assets.Code.Services.AudioService
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class SoundProvider : MonoBehaviour, IAudioSource
    {
        [SerializeField] private AudioClip _clip;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void ChangeVolume(int value)
        {
            _audioSource.volume = value;
        }

        public void Play()
        {
            PlayClip(_audioSource, _clip);
        }

        protected abstract void PlayClip(AudioSource audioSource, AudioClip clip);
    }
}
