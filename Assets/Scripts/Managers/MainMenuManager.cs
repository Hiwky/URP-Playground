using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Event Channels")]
    [SerializeField] private SaveLoadEventChannel SaveLoadEventChannel;
    [SerializeField] private LoadSceneEventChannel LoadSceneEventChannel;

    [SerializeField] private GameStateSO State;

    private void Start()
    {
        State.UpdateGameState(GameState.Pause);
    }
    public void OnClickNewGame()
    {
        LoadSceneEventChannel.RequestLoadScene(StringConstants.SCENE_PLAYGROUND);
        //SceneManager.LoadSceneAsync(StringConstants.SCENE_PLAYGROUND, LoadSceneMode.Additive).completed += UnloadMenu;
        State.UpdateGameState(GameState.Gameplay);
    }

    private void UnloadMenu(AsyncOperation obj)
    {
        SceneManager.UnloadSceneAsync(StringConstants.SCENE_MAIN_MENU);
    }

    public void OnClickLoad()
    {
        SaveLoadEventChannel.RequestLoadData();
        LoadSceneEventChannel.RequestLoadScene(StringConstants.SCENE_PLAYGROUND);
        State.UpdateGameState(GameState.Gameplay);
        //SceneManager.LoadSceneAsync(StringConstants.SCENE_PLAYGROUND, LoadSceneMode.Additive).completed += UnloadMenu;
    }

    public void OnClickQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
