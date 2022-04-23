using System;
using UnityEngine;

namespace Game.Player.PlayerShoot
{
    public class PlayerShoot : MonoBehaviour
    {
        public event Action<GameObject> Shoot;

        private void Update()
        {
            Shoot?.Invoke(gameObject);
        }
    }
}