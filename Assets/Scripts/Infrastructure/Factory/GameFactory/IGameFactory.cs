using UnityEngine;

namespace Infrastructure.Factory.GameFactory
{
    public interface IGameFactory
    {
        GameObject CreatePlayerShip();
    }
}