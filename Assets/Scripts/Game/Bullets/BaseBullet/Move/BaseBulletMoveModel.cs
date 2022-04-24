using UnityEngine;

namespace Game.Bullets.BaseBullet.Move
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