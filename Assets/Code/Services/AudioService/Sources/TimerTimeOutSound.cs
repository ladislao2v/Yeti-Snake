using Assets.Code.Services.AudioService;
using Code.Services.TimerService;
using UnityEngine;

namespace Code.Services.AudioService.Sources
{
    public class TimerTimeOutSound : SoundProvider
    {
        [SerializeField] private Timer _timer;

        private void OnEnable()
        {
            _timer.TimeOut += Play;
        }

        private void OnDisable()
        {
            _timer.TimeOut -= Play;
        }

        protected override void PlayClip(AudioSource audioSource, AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
