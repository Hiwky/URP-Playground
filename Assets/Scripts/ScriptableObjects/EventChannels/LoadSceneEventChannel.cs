using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[CreateAssetMenu(fileName = "LoadSceneEventChannel", menuName = "Scriptable Objects/Event Channels/LoadSceneEventChannel")]
public class LoadSceneEventChannel : ScriptableObject
{
    public event Action OnSceneLoadRequested;

    public string SceneToLoad { get; private set; }

    public void RequestLoadScene(string sceneToLoad)
    {
        Debug.Log($"Request to load {sceneToLoad}");
        SceneToLoad = sceneToLoad;
        OnSceneLoadRequested?.Invoke();
    }
}
