namespace Code.Services.RecordService
{
    public interface IRecordService
    {
        int Record { get; }

        void TryUpdateRecord(int score);
    }
}