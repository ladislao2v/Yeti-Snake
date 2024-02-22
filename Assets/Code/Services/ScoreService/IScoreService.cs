using System;

namespace Code.Services.ScoreService
{
    public interface IScoreService
    {
        event Action<int> Changed;

        void AddScore();
    }
}