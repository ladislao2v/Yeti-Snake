using Code.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Services.AudioService.Sources
{
    public class SnakeDieSound : SoundProvider
    {
        [SerializeField] private Snake _snake;

        private void OnEnable()
        {
            _snake.Died += Play;
        }

        private void OnDisable()
        {
            _snake.Died -= Play;
        }

        protected override void PlayClip(AudioSource audioSource, AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
