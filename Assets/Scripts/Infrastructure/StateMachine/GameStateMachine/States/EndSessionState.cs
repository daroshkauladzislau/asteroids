using Infrastructure.Factory.GameFactory;

namespace Infrastructure.StateMachine.GameStateMachine.States
{
    public class EndSessionState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;

        public EndSessionState(IGameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            _gameFactory.CreateEndSessionHUD();
        }

        public void Exit()
        {
            
        }
    }
}