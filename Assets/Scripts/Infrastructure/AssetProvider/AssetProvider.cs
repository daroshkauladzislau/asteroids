using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        private const string PlayerShipPrefabPath = "";

        public GameObject PlayerShipObject()
        {
            return Resources.Load<GameObject>(PlayerShipPrefabPath);
        }
    }
}