using Infrastructure.StateMachine.GameStateMachine;
using Infrastructure.StateMachine.GameStateMachine.States;

namespace Infrastructure
{
    public class Game
    {
        public IGameStateMachine GameStateMachine;

        public Game()
        {
            GameStateMachine = new GameStateMachine();
            GameStateMachine.Enter<BootstrapState>();
        }
    }
}