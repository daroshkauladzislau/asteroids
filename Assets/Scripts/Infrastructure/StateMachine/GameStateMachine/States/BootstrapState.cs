using Infrastructure.AssetProvider;
using Infrastructure.DI;
using Infrastructure.Factory.GameFactory;
using Services.InputService;
using Services.SceneLoader;

namespace Infrastructure.StateMachine.GameStateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(IGameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _coroutineRunner = coroutineRunner;

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
            SimpleDI.Container.RegisterSingle<ISceneLoader>(new SceneLoader(_coroutineRunner));
            SimpleDI.Container.RegisterSingle<IInputService>(new InputService());
            SimpleDI.Container.RegisterSingle<IAssetProvider>(new AssetProvider.AssetProvider());
            SimpleDI.Container.RegisterSingle<IGameFactory>(new GameFactory(SimpleDI.Container.Single<IAssetProvider>(), SimpleDI.Container.Single<IInputService>()));
        }
    }
}