using Game.AlienSpawner;
using Game.MeteorSpawner;
using Infrastructure.Services.InputService;

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
            EnableInput();
            ActivateSpawners();
        }

        public void Exit()
        {
            DisableInput();
            DeactivateSpawners();
        }

        private void ActivateSpawners()
        {
            _meteorSpawner.StartSpawnMeteors();
            _alienSpawner.StartSpawnAliens();
        }

        private void DeactivateSpawners()
        {
            _meteorSpawner.StopSpawnMeteor();
            _alienSpawner.StopSpawnAliens();
        }

        private void EnableInput() => 
            _inputService.Enable();

        private void DisableInput()
        {
            _inputService.Disable();
        }
    }
}