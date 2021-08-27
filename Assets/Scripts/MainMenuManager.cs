using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Event Channels")]
    [SerializeField] private SaveLoadEventChannel SaveLoadEventChannel;

    [SerializeField] private GameStateSO State;

    private void Start()
    {
        State.UpdateGameState(GameState.Pause);
    }
    public void OnClickNewGame()
    {
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive).completed += UnloadMenu;
        State.UpdateGameState(GameState.Gameplay);
    }

    private void UnloadMenu(AsyncOperation obj)
    {
        SceneManager.UnloadSceneAsync(2);
    }

    public void OnClickLoad()
    {
        SaveLoadEventChannel.RequestLoadData();
        State.UpdateGameState(GameState.Gameplay);
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive).completed += UnloadMenu;
    }

    public void OnClickQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
