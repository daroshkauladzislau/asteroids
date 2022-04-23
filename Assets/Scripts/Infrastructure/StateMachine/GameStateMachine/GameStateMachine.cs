using System;
using System.Collections.Generic;
using Infrastructure.DI;
using Infrastructure.Factory.GameFactory;
using Infrastructure.StateMachine.GameStateMachine.States;
using Services.InputService;
using Services.SceneLoader;

namespace Infrastructure.StateMachine.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(ICoroutineRunner coroutineRunner, SimpleDI simpleDi)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, coroutineRunner, simpleDi),
                [typeof(LoadLevelState)] = new LoadLevelState(this, simpleDi.Single<IGameFactory>(), simpleDi.Single<ISceneLoader>()),
                [typeof(GameLoopState)] = new GameLoopState(this, simpleDi.Single<IInputService>()),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }
    }
}