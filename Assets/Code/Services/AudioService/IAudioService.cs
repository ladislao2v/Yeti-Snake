namespace Code.Services.AudioService
{
    public interface IAudioService
    {        
        public float Current { get; }
        void AddSource(IAudioSource audioSource);
        void ChangeVolume(float value);
    }
}