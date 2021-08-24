using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveLoadEventChannel", menuName = "Scriptable Objects/Event Channels/SaveLoadEventChannel")]
public class SaveLoadEventChannel : ScriptableObject
{
    public event Action OnRequestSaveData;
    public event Action OnRequestLoadData;
    public event Action OnDataReadyToSave;
    public event Action OnDataReadyToLoad;

    public SaveData CurrentSaveData;

    public void RequestSaveData()
    {
        OnRequestSaveData?.Invoke();
    }
    public void RequestLoadData()
    {
        OnRequestLoadData?.Invoke();
    }

    public void RaiseDataReadyToSave()
    {
        OnDataReadyToSave?.Invoke();
    }

    public void RaiseDataReadyToLoad()
    {
        OnDataReadyToLoad?.Invoke();
    }
}
