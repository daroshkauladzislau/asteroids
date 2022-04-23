using UnityEngine;

namespace Game.Bullets
{
    public abstract class BaseGunModel
    {
        public float Speed;
        public float Damage;
        public Vector3 Position;

        protected BaseGunModel(float speed, float damage)
        {
            Speed = speed;
            Damage = damage;
        }
    }
}