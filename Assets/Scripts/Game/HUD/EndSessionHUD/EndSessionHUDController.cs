using System;
using Infrastructure.StateMachine.GameStateMachine;
using Infrastructure.StateMachine.GameStateMachine.States;
using UnityEngine;
using UnityEngine.UI;

namespace Game.HUD.EndSessionHUD
{
    public class EndSessionHUDController
    {
        private readonly EndSessionHUD _endSessionHUD;
        private readonly IGameStateMachine _gameStateMachine;

        public EndSessionHUDController(EndSessionHUD endSessionHUD, IGameStateMachine gameStateMachine)
        {
            _endSessionHUD = endSessionHUD;
            _gameStateMachine = gameStateMachine;

            Subscribe();
        }

        private void Subscribe()
        {
            //UpdateScoreText();
            ConfigurePlayAgainButton();
        }

        // private void UpdateScoreText() => 
        //     _endSessionHUD.ScoreText.Invoke().text = String.Empty;

        private void ConfigurePlayAgainButton() => 
            _endSessionHUD.PlayAgainButton += PlayAgain;

        private void PlayAgain(Button button) => 
            button.onClick.AddListener(PlayAgainLogic);

        private void PlayAgainLogic()
        {
            Debug.Log("Play again");
            _gameStateMachine.Enter<LoadLevelState>();
        }
    }
}