using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure.Services.ScreenLimits
{
    public interface IScreenLimits : IService
    {
        bool OutOfLimits(Vector3 transform);
        Vector3 PositionAfterTeleport(Vector3 transform);
        float LeftLimit();
        float RightLimit();
        float TopLimit();
        float BottomLimit();
    }
}