using Code.Services.AudioService;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI.Elements
{
    public class AudioSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private IAudioService _audioService;

        public void Construct(IAudioService audioService)
        {
            _audioService = audioService;

            _slider.value = _audioService.Current;
        }

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            _audioService.ChangeVolume(value);
        }
    }
}
