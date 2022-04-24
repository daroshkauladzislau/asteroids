using UnityEngine;

namespace Game.Bullets
{
    public abstract class BaseBulletMoveModel
    {
        public float Speed;
        public Vector3 Position;

        protected BaseBulletMoveModel(float speed)
        {
            Speed = speed;
        }
    }
}