using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Code.Leaderboard
{
    public class UserView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _rankText;
        [SerializeField] private TextMeshProUGUI _usernameText;
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void Construct(int rank, string username, int score)
        {
            _rankText.text = rank.ToString();
            _usernameText.text = username;
            _scoreText.text = score.ToString();
        }
    }
}
