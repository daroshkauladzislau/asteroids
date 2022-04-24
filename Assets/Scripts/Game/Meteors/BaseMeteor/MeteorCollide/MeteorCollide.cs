using System;
using UnityEngine;

namespace Game.Meteors.BaseMeteor.MeteorCollide
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public abstract class MeteorCollide : MonoBehaviour
    {
        public event Action<Collider2D> OnCollision;

        protected void OnTriggerEnter2D(Collider2D col)
        {
            OnCollision?.Invoke(col);
        }
    }
}