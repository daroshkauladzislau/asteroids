using UnityEngine;

namespace Game.Meteors.BaseMeteor.MeteorMove
{
    public abstract class MeteorMoveModel
    {
        public float Speed;
        public Vector3 Position;
        public Vector3 Direction;

        protected MeteorMoveModel(float speed, Vector3 direction)
        {
            Speed = speed;
            Direction = direction;
        }
    }
}