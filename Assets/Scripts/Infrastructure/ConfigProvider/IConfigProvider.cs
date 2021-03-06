using GameConfig;
using Infrastructure.DI;

namespace Infrastructure.ConfigProvider
{
    public interface IConfigProvider : IService
    {
        PlayerConfig PlayerConfig();
        GunConfig StandardBulletConfig();
        GunConfig LaserBulletConfig();
        MeteorConfig MeteorConfig();
        AlienConfig AlienConfig();
    }
}