using Code.Services.PauseService;

namespace Code.Services.InputService
{
    public interface IInputService : IPausable
    {
        void Enable();
        void Disable();
    }
}