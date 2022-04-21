using Services.InputService;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player.PlayerMove
{
    public class PlayerMoveController
    {
        private readonly PlayerMoveModel _playerMoveModel;
        private readonly PlayerMove _playerMove;
        private readonly IInputService _inputService;

        public PlayerMoveController(PlayerMoveModel playerMoveModel, PlayerMove playerMove, IInputService inputService)
        {
            _playerMoveModel = playerMoveModel;
            _playerMove = playerMove;
            _inputService = inputService;

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

        private float CurvePoint() => 
            _playerMoveModel.AccelerationCurve.Evaluate(_playerMoveModel.SpeedCurveTime);

        private bool PlayerStartInputForMove() => 
            _inputService.Player.Move.phase == InputActionPhase.Started;
    }
}