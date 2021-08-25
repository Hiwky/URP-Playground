using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Event Channels")]
    [SerializeField] private SaveLoadEventChannel SaveLoadEventChannel;
    public void OnClickNewGame()
    {
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive).completed += UnloadMenu;
    }

    private void UnloadMenu(AsyncOperation obj)
    {
        SceneManager.UnloadSceneAsync(2);
    }

    public void OnClickLoad()
    {
        Debug.Log("Load");
        SaveLoadEventChannel.RequestLoadData();
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive).completed += UnloadMenu;
    }

    public void OnClickQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
