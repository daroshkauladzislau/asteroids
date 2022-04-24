using UnityEngine;

namespace Infrastructure.Services.ScreenLimits
{
    public class ScreenLimits : IScreenLimits
    {
        private const float OffSet = 0.5f;
        private const float WidthToMaintain = 5.0f;

        public ScreenLimits() => 
            SetupScreen();

        public bool OutOfLimits(Vector3 transform) =>
            transform.x > RightLimit() || 
            transform.x < LeftLimit() || 
            transform.y > TopLimit() ||
            transform.y < BottomLimit();

        public Vector3 PositionAfterTeleport(Vector3 transform)
        {
            Vector3 newPosition = new Vector3();
            
            if (transform.x > RightLimit())
            {
                newPosition.x = LeftLimit() + OffSet;
                newPosition.y = transform.y;
            }

            if (transform.x < LeftLimit())
            {
                newPosition.x = RightLimit() - OffSet;
                newPosition.y = transform.y;
            }

            if (transform.y > TopLimit())
            {
                newPosition.x = transform.x;
                newPosition.y = BottomLimit() + OffSet;
            }

            if (transform.y < BottomLimit())
            {
                newPosition.x = transform.x;
                newPosition.y = TopLimit() - OffSet;
            }

            return newPosition;
        }

        public float LeftLimit() => 
            Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x;

        public float RightLimit() => 
            Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, 0.0f)).x;

        public float TopLimit() =>
            Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, 0.0f)).y;

        public float BottomLimit() => 
            Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).y;

        private void SetupScreen()
        {
            float height = Camera.main.orthographicSize * 2.0f;
            float width = height * Camera.main.aspect;

            if (width != WidthToMaintain)
            {
                Camera.main.orthographicSize = WidthToMaintain / Camera.main.aspect;
            }
        }
    }
}