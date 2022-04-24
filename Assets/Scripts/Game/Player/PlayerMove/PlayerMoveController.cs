using Infrastructure.Services.InputService;
using Infrastructure.Services.ScreenLimits;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player.PlayerMove
{
    public class PlayerMoveController
    {
        private readonly PlayerMoveModel _playerMoveModel;
        private readonly PlayerMove _playerMove;
        private readonly IInputService _inputService;
        private readonly IScreenLimits _screenLimits;

        public PlayerMoveController(PlayerMoveModel playerMoveModel, PlayerMove playerMove, IInputService inputService, IScreenLimits screenLimits)
        {
            _playerMoveModel = playerMoveModel;
            _playerMove = playerMove;
            _inputService = inputService;
            _screenLimits = screenLimits;

            Subscribe();
        }

        private void Subscribe()
        {
            _playerMove.MoveShip += MoveShip;
        }

        private void MoveShip(GameObject ship)
        {
            Vector3 distance = ship.transform.up * _playerMoveModel.MaxSpeed * CurvePoint() * Time.deltaTime;
            _playerMoveModel.CurrentPosition = ship.transform.position + distance;
            
            CheckForScreenLimits();
            
            ship.transform.position = _playerMoveModel.CurrentPosition;
            
            ControlSpeedCurve();
        }

        private void ControlSpeedCurve()
        {
            if (PlayerStartInputForMove())
            {
                if (CurvePoint() >= 1.0f)
                    _playerMoveModel.SpeedCurveTime = 1.0f;
                else
                    _playerMoveModel.SpeedCurveTime += Time.deltaTime;
            }
            else
            {
                if (CurvePoint() <= 0.0f)
                    _playerMoveModel.SpeedCurveTime = 0.0f;
                else
                    _playerMoveModel.SpeedCurveTime -= Time.deltaTime;
            }
        }

        private void CheckForScreenLimits()
        {
            if (_screenLimits.OutOfLimits(_playerMoveModel.CurrentPosition))
            {
                _playerMoveModel.CurrentPosition = _screenLimits.PositionAfterTeleport(_playerMoveModel.CurrentPosition);
            }
        }

        private float CurvePoint() => 
            _playerMoveModel.AccelerationCurve.Evaluate(_playerMoveModel.SpeedCurveTime);

        private bool PlayerStartInputForMove() => 
            _inputService.Player.Move.phase == InputActionPhase.Started;
    }
}