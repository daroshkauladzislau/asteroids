using System;
using UnityEngine;

namespace Game.Bullets
{
    public abstract class BaseBulletMove : MonoBehaviour
    {
        public event Action<GameObject> Move;

        protected virtual void Update()
        {
            Move?.Invoke(gameObject);
        }
    }
}