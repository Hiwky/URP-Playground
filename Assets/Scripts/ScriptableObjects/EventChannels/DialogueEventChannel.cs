using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System;

//[CreateAssetMenu(fileName = "DialogueEventChannel", menuName = "Scriptable Objects/Event Channels/DialogueEventChannel")]
public class DialogueEventChannel : ScriptableObject
{
    public event Action OnDialogueStarted;
    public event Action OnDialogueEnded;

    private string _currentPath;

    public void RaiseDialogueStartedEvent()
    {
        OnDialogueStarted?.Invoke();
    }

    public void RaiseDialogueEndedEvent()
    {
        OnDialogueEnded?.Invoke();
    }

    public string GetCurrentPath()
    {
        return _currentPath;
    }

    public void SetCurrentPath(string newPath)
    {
        _currentPath = newPath;
    }
}
