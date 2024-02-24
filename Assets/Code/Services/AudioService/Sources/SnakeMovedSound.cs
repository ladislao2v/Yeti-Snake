using Code.Snake;
using UnityEngine;

namespace Assets.Code.Services.AudioService.Sources
{
    public class SnakeMovedSound : SoundProvider
    {
        [SerializeField] private Snake _snake;

        private void OnEnable()
        {
            _snake.Moved += Play;
        }

        private void OnDisable()
        {
            _snake.Moved -= Play;
        }

        protected override void PlayClip(AudioSource audioSource, AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
