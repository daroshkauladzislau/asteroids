using Infrastructure.Factory.GameFactory;
using Infrastructure.StateMachine.GameStateMachine;
using Infrastructure.StateMachine.GameStateMachine.States;

namespace Game.HUD.EndSessionHUD
{
    public class EndSessionHUDController
    {
        private readonly EndSessionHUD _endSessionHUD;
        private readonly IGameFactory _gameFactory;
        private readonly IGameStateMachine _gameStateMachine;

        public EndSessionHUDController(EndSessionHUD endSessionHUD, IGameFactory gameFactory, IGameStateMachine gameStateMachine)
        {
            _endSessionHUD = endSessionHUD;
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;

            Subscribe();
        }

        private void Subscribe()
        {
            UpdateScoreText();
            ConfigurePlayAgainButton();
        }

        private void UpdateScoreText() => 
            _endSessionHUD.ScoreText.text = $"Score: {_gameFactory.GameScore.CurrentScore}";


        private void ConfigurePlayAgainButton() => 
            _endSessionHUD.PlayAgainButton.onClick.AddListener(PlayAgainLogic);

        private void PlayAgainLogic() => 
            _gameStateMachine.Enter<LoadLevelState>();
    }
}