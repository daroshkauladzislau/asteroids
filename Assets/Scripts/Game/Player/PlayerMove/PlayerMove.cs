using System;
using UnityEngine;

namespace Game.Player.PlayerMove
{
    public class PlayerMove : MonoBehaviour
    {
        public event Action<GameObject> MoveShip;

        private void Update()
        {
            MoveShip?.Invoke(gameObject);
        }
    }
}