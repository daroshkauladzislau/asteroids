using GameConfig;
using UnityEngine;

namespace Infrastructure.ConfigProvider
{
    public class ConfigProvider : IConfigProvider
    {
        private const string StandardBulletConfigPath = "Configs/Game/Gun/StandardBullet/StandardBullet";
        private const string PlayerConfigPath = "Configs/Game/Player/PlayerConfig";
        private const string MeteorConfigPath = "Configs/Game/Meteor/Meteor";

        public PlayerConfig PlayerConfig() => 
            Resources.Load<PlayerConfig>(PlayerConfigPath);

        public GunConfig StandardBulletConfig() => 
            Resources.Load<GunConfig>(StandardBulletConfigPath);

        public MeteorConfig MeteorConfig() => 
            Resources.Load<MeteorConfig>(MeteorConfigPath);
    }
}