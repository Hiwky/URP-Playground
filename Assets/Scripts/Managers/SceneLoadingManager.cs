using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    [Header("Event Channels")]
    [SerializeField] private LoadSceneEventChannel LoadSceneEventChannel;

    private string _currentLocationScene;
    void Start()
    {
        LoadSceneEventChannel.OnSceneLoadRequested += LoadScene;
        _currentLocationScene = StringConstants.SCENE_MAIN_MENU;
    }

    private void LoadScene()
    {
        SceneManager.LoadSceneAsync(LoadSceneEventChannel.SceneToLoad, LoadSceneMode.Additive).completed += UnloadCurrentScene;
    }

    private void UnloadCurrentScene(AsyncOperation obj)
    {
        SceneManager.UnloadSceneAsync(_currentLocationScene);
        _currentLocationScene = LoadSceneEventChannel.SceneToLoad;
    }
}
