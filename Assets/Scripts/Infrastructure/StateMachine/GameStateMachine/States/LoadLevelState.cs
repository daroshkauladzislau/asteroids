using Infrastructure.Factory.GameFactory;

namespace Infrastructure.StateMachine.GameStateMachine.States
{
    public class LoadLevelState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(IGameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }
        
        public void Enter()
        {
            CreateGameWorld();
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }

        private void CreateGameWorld()
        {
            _gameFactory.CreatePlayerShip();
        }
    }
}