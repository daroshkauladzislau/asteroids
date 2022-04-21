using Game.Player.PlayerMove;
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
            PlayerMoveModel playerShipMoveModel = new PlayerMoveModel(playerConfig.MaxSpeed,
                playerConfig.AccelerationCurve);
            GameObject playerShip = Object.Instantiate(_assetProvider.PlayerShipObject());
            PlayerMove playerShipMoveComponent = playerShip.GetComponent<PlayerMove>();
            PlayerMoveController playerMoveController =
                new PlayerMoveController(playerShipMoveModel, playerShipMoveComponent, _inputService);
            return playerShip;
        }
    }
}