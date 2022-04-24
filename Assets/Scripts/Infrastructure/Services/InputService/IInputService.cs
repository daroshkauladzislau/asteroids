using Infrastructure.DI;

namespace Infrastructure.Services.InputService
{
    public interface IInputService : IService
    {
        InputService.PlayerActions @Player { get; }
        void Enable();
        void Disable();
    }
}