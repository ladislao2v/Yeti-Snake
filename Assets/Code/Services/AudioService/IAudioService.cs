namespace Code.Services.AudioService
{
    public interface IAudioService
    {        
        void AddSource(IAudioSource audioSource);
        void ChangeVolume(int value);
    }
}