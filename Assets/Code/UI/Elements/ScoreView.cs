﻿using TMPro;
using UnityEngine;

namespace Code.UI.Elements
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;

        public void Render(int score)
        {
            _counter.text = score.ToString();
        }
    }
}