using System;
using UnityEngine;

namespace Game.Bullets
{
    public abstract class BaseGun : MonoBehaviour
    {
        public event Action<GameObject> Move;
        public event Action<Collision2D> OnCollide;

        protected virtual void Update()
        {
            Move?.Invoke(gameObject);
        }

        protected virtual void OnCollisionEnter2D(Collision2D col)
        {
            OnCollide?.Invoke(col);
        }
    }
}