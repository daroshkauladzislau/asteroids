using System;
using System.Collections;
using Infrastructure.GameBootstrapper;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Load(string sceneName, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadLevelRoutine(sceneName, onLoaded));
        }

        private IEnumerator LoadLevelRoutine(string sceneName, Action onLoaded)
        {
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneAsync.isDone)
            {
                yield return null;
            }
            
            onLoaded?.Invoke();
        }
    }
}