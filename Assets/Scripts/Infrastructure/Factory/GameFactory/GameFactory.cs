using Game.Player.PlayerMove;
using Game.Player.PlayerRotate;
using GameConfig;
using Infrastructure.AssetProvider;
using Services.InputService;
using UnityEngine;

namespace Infrastructure.Factory.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInputService _inputService;

        public GameFactory(IAssetProvider assetProvider, IInputService inputService)
        {
            _assetProvider = assetProvider;
            _inputService = inputService;
        }
        
        public GameObject CreatePlayerShip()
        {
            PlayerConfig playerConfig = _assetProvider.PlayerConfig();
            
            GameObject playerShip = Object.Instantiate(_assetProvider.PlayerShipObject());
            
            ConfigurePlayerMove(playerConfig, playerShip);
            ConfigurePlayerRotate(playerShip, playerConfig);

            return playerShip;
        }

        private void ConfigurePlayerRotate(GameObject playerShip, PlayerConfig playerConfig)
        {
            PlayerRotate playerShipRotateComponent = playerShip.GetComponent<PlayerRotate>();
            PlayerRotateModel playerRotateModel = new PlayerRotateModel(playerConfig.RotationSpeed);
            PlayerRotateController playerRotateController =
                new PlayerRotateController(playerRotateModel, playerShipRotateComponent, _inputService);
        }

        private void ConfigurePlayerMove(PlayerConfig playerConfig, GameObject playerShip)
        {
            PlayerMoveModel playerShipMoveModel = new PlayerMoveModel(playerConfig.MaxSpeed,
                playerConfig.AccelerationCurve);
            PlayerMove playerShipMoveComponent = playerShip.GetComponent<PlayerMove>();
            PlayerMoveController playerMoveController =
                new PlayerMoveController(playerShipMoveModel, playerShipMoveComponent, _inputService);
        }
    }
}