using System;
using UnityEngine;

namespace Game.Bullets.BaseBullet.Collide
{
    public abstract class BaseBulletCollide : MonoBehaviour
    {
        public event Action<Collider2D> OnCollide;
        protected virtual void OnTriggerEnter2D(Collider2D col)
        {
            OnCollide?.Invoke(col);
        }
    }
}