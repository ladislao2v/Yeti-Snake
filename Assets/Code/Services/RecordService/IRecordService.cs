using UnityEngine;

namespace Code.Services.RecordService
{
    public interface IRecordService
    {
        int Record { get; }

        void Load();
        void TryUpdateRecord(int score);
    }
}