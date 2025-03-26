using System.Collections;
using System.Collections.Generic;
using TB_RPG_2D.EventSystem;
using TB_RPG_2D.EventSystem.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TB_RPG_2D.Scene
{
    public class CustomSceneManager : MonoBehaviour
    {
        private GameScene _currentScene;
        private bool _isLoading;
        private readonly HashSet<string> _cachedSceneNames = new();
        
        private EventBinding<LoadSceneRequestEvent> _loadSceneRequestEventBinding;
        
        private void Awake()
        {
            CacheBuildScenes();
            
            _loadSceneRequestEventBinding = new EventBinding<LoadSceneRequestEvent>(OnLoadSceneRequest);
            EventBus<LoadSceneRequestEvent>.Subscribe(_loadSceneRequestEventBinding);
        }
        
        private void OnDestroy()
        {
            EventBus<LoadSceneRequestEvent>.Unsubscribe(_loadSceneRequestEventBinding);
        }

        private void OnLoadSceneRequest(LoadSceneRequestEvent loadSceneRequestEvent)
        {
            LoadScene(loadSceneRequestEvent.Scene);
        }

        private void Start()
        {
            LoadFirstScene();
        }

        private void LoadFirstScene()
        {
            LoadScene(GameScene.HeroSelectionScene);
        }

        private void LoadScene(GameScene sceneKey)
        {
            if (_isLoading || _currentScene == sceneKey)
            {
                Debug.LogWarning($"Scene '{GetSceneName(sceneKey)}' is already loading or loaded.");
                return;
            }

            StartCoroutine(LoadSceneAsync(sceneKey));
        }

        private IEnumerator LoadSceneAsync(GameScene sceneKey)
        {
            _isLoading = true;
            string sceneName = GetSceneName(sceneKey);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            if (asyncLoad == null)
            {
                Debug.LogError($"[Scene Error] Failed to load scene '{sceneName}'.");
                _isLoading = false;
                yield break;
            }

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            _currentScene = sceneKey;
            CleanupScenes(sceneKey);
            
            _isLoading = false;
        }

        private void CleanupScenes(GameScene loadedSceneKey)
        {
            List<string> scenesToUnload = new List<string>();

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                UnityEngine.SceneManagement.Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name != GetSceneName(GameScene.PersistentScene) && scene.name != GetSceneName(loadedSceneKey))
                {
                    scenesToUnload.Add(scene.name);
                }
            }

            foreach (var sceneName in scenesToUnload)
            {
                SceneManager.UnloadSceneAsync(sceneName);
            }
        }

        private string GetSceneName(GameScene scene)
        {
            string sceneName = scene.ToString();

            if (!IsSceneInBuildSettings(sceneName))
            {
                Debug.LogError(
                    $"[Scene Error] The scene '{sceneName}' mapped from enum '{scene}' is not added to Build Settings or the name is incorrect.");
            }

            return sceneName;
        }

        private void CacheBuildScenes()
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            for (int i = 0; i < sceneCount; i++)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(i);
                string sceneName = System.IO.Path.GetFileNameWithoutExtension(path);
                _cachedSceneNames.Add(sceneName);
            }
        }

        private bool IsSceneInBuildSettings(string sceneName) => _cachedSceneNames.Contains(sceneName);
    }
}