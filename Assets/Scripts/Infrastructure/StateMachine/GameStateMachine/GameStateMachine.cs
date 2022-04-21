using System;
using System.Collections.Generic;
using Infrastructure.DI;
using Infrastructure.Factory.GameFactory;
using Infrastructure.StateMachine.GameStateMachine.States;
using Services.InputService;

namespace Infrastructure.StateMachine.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this),
                [typeof(LoadLevelState)] = new LoadLevelState(this, SimpleDI.Container.Single<IGameFactory>()),
                [typeof(GameLoopState)] = new GameLoopState(this, SimpleDI.Container.Single<IInputService>()),
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