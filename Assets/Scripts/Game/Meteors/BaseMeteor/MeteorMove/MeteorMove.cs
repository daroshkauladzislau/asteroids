using System;
using UnityEngine;

namespace Game.Meteors.BaseMeteor.MeteorMove
{
    public abstract class MeteorMove : MonoBehaviour
    {
        public event Action<GameObject> Move;

        protected virtual void Update()
        {
            Move?.Invoke(gameObject);
        }
    }
}