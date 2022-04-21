using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure.Factory.GameFactory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayerShip();
    }
}