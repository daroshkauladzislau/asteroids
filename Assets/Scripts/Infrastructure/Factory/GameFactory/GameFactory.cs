using Infrastructure.AssetProvider;
using UnityEngine;

namespace Infrastructure.Factory.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public GameObject CreatePlayerShip()
        {
            return Object.Instantiate(_assetProvider.PlayerShipObject());
        }
    }
}