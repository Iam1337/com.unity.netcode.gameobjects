using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Unity.Netcode
{
    /// <summary>
    /// Used to override the LoadSceneAsync and UnloadSceneAsync methods called
    /// within the NetworkSceneManager.
    /// </summary>
    internal interface ISceneManagerHandler
    {
        AsyncOperationHandle<SceneInstance> LoadSceneAsync(AssetReference sceneReference, LoadSceneMode loadSceneMode, SceneEventProgress sceneEventProgress);

        AsyncOperationHandle<SceneInstance> UnloadSceneAsync(SceneInstance sceneInstance, SceneEventProgress sceneEventProgress);

        void PopulateLoadedScenes(ref Dictionary<int, Scene> scenesLoaded, NetworkManager networkManager = null);
        Scene GetSceneFromLoadedScenes(SceneInstance sceneInstance, NetworkManager networkManager = null);

        bool DoesSceneHaveUnassignedEntry(Scene targetScene, NetworkManager networkManager = null);

        void StopTrackingScene(int handle, AssetReference sceneReference, NetworkManager networkManager = null);

        void StartTrackingScene(Scene scene, bool assigned, NetworkManager networkManager = null);

        void ClearSceneTracking(NetworkManager networkManager = null);

        void UnloadUnassignedScenes(NetworkManager networkManager = null);

        void MoveObjectsFromSceneToDontDestroyOnLoad(ref NetworkManager networkManager, Scene scene);

        void SetClientSynchronizationMode(ref NetworkManager networkManager, LoadSceneMode mode);
    }
}
