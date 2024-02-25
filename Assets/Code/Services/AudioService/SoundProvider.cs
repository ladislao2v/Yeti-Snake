using Code.Services.AudioService;
using UnityEngine;

namespace Assets.Code.Services.AudioService
{
    public abstract class SoundProvider : MonoBehaviour, IAudioSource
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _clip;

        private void Awake()
        {
            _audioSource ??= GetComponent<AudioSource>();
        }

        public void ChangeVolume(float value)
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
