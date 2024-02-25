using UnityEngine;

namespace Code.Services.RecordService
{
    public class RecordService : IRecordService
    {
        private const string RecordKey = nameof(RecordKey);
        private int _record;

        public int Record => _record;

        public RecordService()
        {
            _record = PlayerPrefs.GetInt(RecordKey);
        }
        
        public void TryUpdateRecord(int score)
        {
            if (score <= _record) 
                return;
            
            _record = score;

            Save();
        }

        private void Save()
        {
            PlayerPrefs.SetInt(RecordKey, _record);
            PlayerPrefs.Save();
        }
    }
}