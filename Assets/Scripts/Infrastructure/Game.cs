using Infrastructure.DI;
using Infrastructure.StateMachine.GameStateMachine;
using Infrastructure.StateMachine.GameStateMachine.States;

namespace Infrastructure
{
    public class Game
    {
        public IGameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner, SimpleDI simpleDi)
        {
            GameStateMachine = new GameStateMachine(coroutineRunner, simpleDi);
            GameStateMachine.Enter<BootstrapState>();
        }
    }
}