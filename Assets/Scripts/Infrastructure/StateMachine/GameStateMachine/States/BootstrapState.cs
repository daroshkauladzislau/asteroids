using Infrastructure.AssetProvider;
using Infrastructure.DI;
using Infrastructure.Factory.GameFactory;
using Services.InputService;
using Services.SceneLoader;
using Services.ScreenLimits;

namespace Infrastructure.StateMachine.GameStateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly SimpleDI _simpleDi;

        public BootstrapState(IGameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner, SimpleDI simpleDi)
        {
            _gameStateMachine = gameStateMachine;
            _coroutineRunner = coroutineRunner;
            _simpleDi = simpleDi;

            RegisterServices();
        }

        public void Enter()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            _simpleDi.RegisterSingle<IScreenLimits>(new ScreenLimits());
            _simpleDi.RegisterSingle<ISceneLoader>(new SceneLoader(_coroutineRunner));
            _simpleDi.RegisterSingle<IInputService>(new InputService());
            _simpleDi.RegisterSingle<IAssetProvider>(new AssetProvider.AssetProvider());
            _simpleDi.RegisterSingle<IGameFactory>(new GameFactory(_simpleDi.Single<IAssetProvider>(), 
                _simpleDi.Single<IInputService>(), 
                _simpleDi.Single<IScreenLimits>()));
        }
    }
}