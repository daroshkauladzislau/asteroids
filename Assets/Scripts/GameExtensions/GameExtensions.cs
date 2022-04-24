using UnityEngine;

namespace GameExtensions
{
    public static class GameExtensions
    {
        public static void LookAt2D(this Transform transform, Vector2 direction)
        {
            Vector2 diff = direction - (Vector2)transform.position;
            diff.Normalize();

            float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90.0f);
        }
    }
}