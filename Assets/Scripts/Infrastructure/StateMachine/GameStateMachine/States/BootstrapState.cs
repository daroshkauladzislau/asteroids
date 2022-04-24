using Game.MeteorSpawner;
using Infrastructure.AssetProvider;
using Infrastructure.ConfigProvider;
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
            RegisterScreenLimit();
            RegisterSceneLoader();
            RegisterInputService();
            RegisterAssetProvider();
            RegisterConfigProvider();
            RegisterGameFactory();
            RegisterMeteorSpawner();
        }

        private void RegisterMeteorSpawner()
        {
            _simpleDi.RegisterSingle<IMeteorSpawner>(new MeteorSpawner(_coroutineRunner,
                _simpleDi.Single<IGameFactory>(), _simpleDi.Single<IScreenLimits>(), _simpleDi.Single<IConfigProvider>()));
        }

        private void RegisterGameFactory() =>
            _simpleDi.RegisterSingle<IGameFactory>(new GameFactory(_simpleDi.Single<IAssetProvider>(),
                _simpleDi.Single<IConfigProvider>(), _simpleDi.Single<IInputService>(), _simpleDi.Single<IScreenLimits>()));

        private void RegisterConfigProvider() => 
            _simpleDi.RegisterSingle<IConfigProvider>(new ConfigProvider.ConfigProvider());

        private void RegisterAssetProvider() => 
            _simpleDi.RegisterSingle<IAssetProvider>(new AssetProvider.AssetProvider());

        private void RegisterInputService() => 
            _simpleDi.RegisterSingle<IInputService>(new InputService());

        private void RegisterSceneLoader() => 
            _simpleDi.RegisterSingle<ISceneLoader>(new SceneLoader(_coroutineRunner));

        private void RegisterScreenLimit() => 
            _simpleDi.RegisterSingle<IScreenLimits>(new ScreenLimits());
    }
}