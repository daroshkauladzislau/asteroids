using Infrastructure.Factory.GameFactory;
using Services.SceneLoader;
using UnityEngine;

namespace Infrastructure.StateMachine.GameStateMachine.States
{
    public class LoadLevelState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(IGameStateMachine gameStateMachine, IGameFactory gameFactory, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            Debug.Log("Enter load level");
            _sceneLoader.Load("Game", CreateGameWorld);
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }

        private void CreateGameWorld()
        {
            _gameFactory.CreatePlayerShip();
            _gameFactory.CreateHUD();
        }
    }
}