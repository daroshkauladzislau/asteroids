using UnityEngine;

namespace Game.Aliens.Collide
{
    public class AlienCollideController
    {
        private readonly AlienCollide _alienCollide;

        public AlienCollideController(AlienCollide alienCollide)
        {
            _alienCollide = alienCollide;

            Subscribe();
        }

        private void Subscribe()
        {
            _alienCollide.OnCollide += OnCollide;
        }

        private void OnCollide(Collider2D obj)
        {
            
        }
    }
}