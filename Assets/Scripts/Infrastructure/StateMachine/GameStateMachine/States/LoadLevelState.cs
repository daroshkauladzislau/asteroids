using Infrastructure.Factory.GameFactory;
using Infrastructure.Services.SceneLoader;
using UnityEngine;

namespace Infrastructure.StateMachine.GameStateMachine.States
{
    public class LoadLevelState : IState
    {
        private const string GameSceneName = "Game";
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
            _sceneLoader.Load(GameSceneName, CreateGameWorld);
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }

        private void CreateGameWorld()
        {
            _gameFactory.CreateGameScore();
            _gameFactory.CreatePlayerShip();
            _gameFactory.CreateHUD();
        }
    }
}