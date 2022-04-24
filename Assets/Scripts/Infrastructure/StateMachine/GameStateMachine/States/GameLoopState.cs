using Game.MeteorSpawner;
using Services.InputService;

namespace Infrastructure.StateMachine.GameStateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IInputService _inputService;
        private readonly IMeteorSpawner _meteorSpawner;

        public GameLoopState(IGameStateMachine gameStateMachine, IInputService inputService, IMeteorSpawner meteorSpawner)
        {
            _gameStateMachine = gameStateMachine;
            _inputService = inputService;
            _meteorSpawner = meteorSpawner;
        }
        
        public void Enter()
        {
            _inputService.Enable();
            _meteorSpawner.StartSpawnMeteors();
        }

        public void Exit()
        {
            _inputService.Disable();
            _meteorSpawner.StopSpawnMeteor();
        }
    }
}