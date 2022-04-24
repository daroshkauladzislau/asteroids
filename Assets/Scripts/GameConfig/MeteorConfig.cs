using UnityEngine;

namespace GameConfig
{
    [CreateAssetMenu(fileName = "Default Meteor Config", menuName = "Game Config/Meteor")]
    public class MeteorConfig : ScriptableObject
    {
        public float BigMeteorSpeed;
        public float SmallMeteorSpeed;
        public float SpawnDelay;
        public int MeteorsAfterDestroy;
    }
}