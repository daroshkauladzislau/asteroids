using Infrastructure.AssetProvider;
using Infrastructure.DI;
using Infrastructure.Factory.GameFactory;
using Services.InputService;

namespace Infrastructure.StateMachine.GameStateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;

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
            RegisterInputService();
            
            SimpleDI.Container.RegisterSingle<IAssetProvider>(new AssetProvider.AssetProvider());
            SimpleDI.Container.RegisterSingle<IGameFactory>(new GameFactory(SimpleDI.Container.Single<IAssetProvider>(), SimpleDI.Container.Single<IInputService>()));
        }

        private void RegisterInputService()
        {
            SimpleDI.Container.RegisterSingle<IInputService>(new InputService());
        }
    }
}