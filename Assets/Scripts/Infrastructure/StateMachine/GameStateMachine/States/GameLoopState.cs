using Services.InputService;

namespace Infrastructure.StateMachine.GameStateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IInputService _inputService;

        public GameLoopState(IGameStateMachine gameStateMachine, IInputService inputService)
        {
            _gameStateMachine = gameStateMachine;
            _inputService = inputService;
        }
        
        public void Enter()
        {
            _inputService.Enable();
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}