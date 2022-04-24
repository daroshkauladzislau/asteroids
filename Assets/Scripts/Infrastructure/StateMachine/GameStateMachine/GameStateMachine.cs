using System;
using System.Collections.Generic;
using Game.AlienSpawner;
using Game.MeteorSpawner;
using Infrastructure.DI;
using Infrastructure.Factory.GameFactory;
using Infrastructure.GameBootstrapper;
using Infrastructure.Services.InputService;
using Infrastructure.Services.SceneLoader;
using Infrastructure.StateMachine.GameStateMachine.States;

namespace Infrastructure.StateMachine.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(ICoroutineRunner coroutineRunner, SimpleDI simpleDi)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, coroutineRunner, simpleDi),
                [typeof(LoadLevelState)] = new LoadLevelState(this, simpleDi.Single<IGameFactory>(), simpleDi.Single<ISceneLoader>()),
                [typeof(GameLoopState)] = new GameLoopState(this, simpleDi.Single<IInputService>(), simpleDi.Single<IMeteorSpawner>(), simpleDi.Single<IAlienSpawner>()),
                [typeof(EndSessionState)] = new EndSessionState(this, simpleDi.Single<IGameFactory>()),
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