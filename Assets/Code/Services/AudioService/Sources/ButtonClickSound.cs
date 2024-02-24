using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Services.AudioService.Sources
{
    [RequireComponent(typeof(Button))] 
    public class ButtonClickSound : SoundProvider
    {
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(Play);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Play);
        }

        protected override void PlayClip(AudioSource audioSource, AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
