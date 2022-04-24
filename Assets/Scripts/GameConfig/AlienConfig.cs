using UnityEngine;

namespace GameConfig
{
    [CreateAssetMenu(fileName = "Default Alien Config", menuName = "Game Config/Alien")]
    public class AlienConfig : ScriptableObject
    {
        public float Speed;
        public float SpawnDelay;
    }
}