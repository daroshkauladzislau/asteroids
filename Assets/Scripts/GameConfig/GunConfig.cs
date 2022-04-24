using UnityEngine;

namespace GameConfig
{
    [CreateAssetMenu(fileName = "Default Gun Config", menuName = "Game Config/Gun")]
    public class GunConfig : ScriptableObject
    {
        public float Speed;
    }
}