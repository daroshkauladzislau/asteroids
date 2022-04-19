using Infrastructure.DI;
using Services.InputService;

namespace Infrastructure.StateMachine.GameStateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;

            RegisterServices();
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            RegisterInputService();
        }

        private void RegisterInputService()
        {
            SimpleDI.Container.RegisterSingle<IInputService>(new InputService());
        }
    }
}