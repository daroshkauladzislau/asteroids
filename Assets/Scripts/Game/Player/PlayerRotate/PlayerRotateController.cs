using Infrastructure.Services.InputService;
using UnityEngine;

namespace Game.Player.PlayerRotate
{
    public class PlayerRotateController
    {
        private readonly PlayerRotateModel _playerRotateModel;
        private readonly PlayerRotate _playerRotate;
        private readonly IInputService _inputService;

        public PlayerRotateController(PlayerRotateModel playerRotateModel, PlayerRotate playerRotate, IInputService inputService)
        {
            _playerRotateModel = playerRotateModel;
            _playerRotate = playerRotate;
            _inputService = inputService;

            Subscribe();
        }

        private void Subscribe()
        {
            _playerRotate.RotateShip += RotateShip;
        }

        private void RotateShip(GameObject ship)
        {
            if (_inputService.Player.Rotate.ReadValue<Vector2>() != Vector2.zero)
            {
                _playerRotateModel.RotateAngle += _inputService.Player.Rotate.ReadValue<Vector2>().x *
                                                  _playerRotateModel.RotateSpeed * Time.deltaTime;
                ControlAngleValue();
                
                ship.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -_playerRotateModel.RotateAngle);
            }
        }

        private void ControlAngleValue()
        {
            if (_playerRotateModel.RotateAngle > 360.0f)
            {
                _playerRotateModel.RotateAngle = 0.0f;
            }
            else if (_playerRotateModel.RotateAngle < 0.0f)
            {
                _playerRotateModel.RotateAngle = 360.0f;
            }
        }
    }
}