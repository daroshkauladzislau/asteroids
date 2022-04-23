using Infrastructure.DI;
using UnityEngine;

namespace Services.ScreenLimits
{
    public interface IScreenLimits : IService
    {
        bool OutOfLimits(Vector3 transform);
        Vector3 PositionAfterTeleport(Vector3 transform);
    }
}