using System;
using Infrastructure.DI;

namespace Infrastructure.Services.SceneLoader
{
    public interface ISceneLoader : IService
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}