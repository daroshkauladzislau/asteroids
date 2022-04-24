using Game.AlienSpawner;
using Game.MeteorSpawner;
using Services.InputService;

namespace Infrastructure.StateMachine.GameStateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IInputService _inputService;
        private readonly IMeteorSpawner _meteorSpawner;
        private readonly IAlienSpawner _alienSpawner;

        public GameLoopState(IGameStateMachine gameStateMachine, IInputService inputService, IMeteorSpawner meteorSpawner, IAlienSpawner alienSpawner)
        {
            _gameStateMachine = gameStateMachine;
            _inputService = inputService;
            _meteorSpawner = meteorSpawner;
            _alienSpawner = alienSpawner;
        }
        
        public void Enter()
        {
            _inputService.Enable();
            _meteorSpawner.StartSpawnMeteors();
            _alienSpawner.StartSpawnAliens();
        }

        public void Exit()
        {
            _inputService.Disable();
            _meteorSpawner.StopSpawnMeteor();
            _alienSpawner.StopSpawnAliens();
        }
    }
}