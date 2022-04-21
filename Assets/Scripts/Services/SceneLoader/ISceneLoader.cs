using System;
using Infrastructure.DI;

namespace Services.SceneLoader
{
    public interface ISceneLoader : IService
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}