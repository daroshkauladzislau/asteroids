using System;
using UnityEngine;

namespace Game.Player.PlayerCollide
{
    public class PlayerCollide : MonoBehaviour
    {
        public event Action<Collider2D> OnCollide;

        private void OnTriggerEnter2D(Collider2D col)
        {
            OnCollide?.Invoke(col);
        }
    }
}