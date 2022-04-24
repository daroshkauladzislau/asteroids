using Game.Aliens.Collide;
using Game.Meteors.BaseMeteor.MeteorCollide;
using Infrastructure.StateMachine.GameStateMachine;
using Infrastructure.StateMachine.GameStateMachine.States;
using UnityEngine;

namespace Game.Player.PlayerCollide
{
    public class PlayerCollideController
    {
        private readonly PlayerCollide _playerCollide;
        private readonly IGameStateMachine _gameStateMachine;

        public PlayerCollideController(PlayerCollide playerCollide, IGameStateMachine gameStateMachine)
        {
            _playerCollide = playerCollide;
            _gameStateMachine = gameStateMachine;

            Subscribe();
        }

        private void Subscribe()
        {
            _playerCollide.OnCollide += OnCollide;
        }

        private void OnCollide(Collider2D obj)
        {
            if (obj.gameObject.TryGetComponent(out MeteorCollide meteorCollide) ||
                obj.gameObject.TryGetComponent(out AlienCollide alienCollide))
            {
                _playerCollide.gameObject.SetActive(false);
                _gameStateMachine.Enter<EndSessionState>();
            }
        }
    }
}