using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private int _levelIndex;
        [SerializeField] private Button _button;

        public int LevelIndex => _levelIndex;
        
        public event Action<LevelButton> Clicked;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            Clicked?.Invoke(this);
        }
    }
}