using System;
using UnityEngine;

namespace Game.Player.PlayerRotate
{
    public class PlayerRotate : MonoBehaviour
    {
        public event Action<GameObject> RotateShip;

        private void Update()
        {
            RotateShip?.Invoke(gameObject);
        }
    }
}