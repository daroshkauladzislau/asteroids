using System;
using UnityEngine;

namespace Game.Aliens.Collide
{
    public class AlienCollide : MonoBehaviour
    {
        public event Action<Collider2D> OnCollide;

        private void OnTriggerEnter2D(Collider2D col)
        {
            OnCollide?.Invoke(col);
        }
    }
}

