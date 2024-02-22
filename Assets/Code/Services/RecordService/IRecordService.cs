using Unity.VisualScripting;
using UnityEngine;

namespace Code.Services.RecordService
{
    public interface IRecordService
    {
        int Record { get; }

        void Load();
        void TryUpdateRecord(int score);
    }

    public class RecordService : IRecordService
    {
        private const string RecordKey = nameof(RecordKey);
        private int _record;

        public int Record => _record;
        
        public void TryUpdateRecord(int score)
        {
            if (score <= _record) 
                return;
            
            _record = score;

            Save();
        }

        public void Load()
        {
            _record = PlayerPrefs.GetInt(RecordKey);
        }

        private void Save()
        {
            PlayerPrefs.SetInt(RecordKey, _record);
            PlayerPrefs.Save();
        }
    }
}