using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private SaveLoadEventChannel SaveLoadEventChannel;
    [SerializeField] private GameInputSO Input;
    [SerializeField] private GameStateSO State;
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject DefaultSelectedObject;

    private bool isPaused;
    private EventSystem _eventSystem;

    private void Start()
    {
        _eventSystem = EventSystem.current;
        isPaused = false;
        Input.OnPausePressed += HandlePausePressed;
    }

    private void HandlePausePressed()
    {
        if (!isPaused)
            Pause();
        else
            Return();
    }

    private void Pause()
    {
        PauseScreen.SetActive(true);
        ReselectObject();
        State.UpdateGameState(GameState.Pause);
        isPaused = true;
    }

    public void Save()
    {
        SaveLoadEventChannel.RequestSaveData();
    }

    public void Load()
    {
        SaveLoadEventChannel.RequestLoadData();
    }

    public void Return()
    {
        Debug.Log("Return");
        PauseScreen.SetActive(false);
        State.ResetToPreviousGameState();
        isPaused = false;
    }

    public void OnClickQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void ReselectObject()
    {
        _eventSystem.SetSelectedGameObject(null);
        _eventSystem.SetSelectedGameObject(DefaultSelectedObject);
    }
}
