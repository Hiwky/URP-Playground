using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IInteractive
{
    [SerializeField] private DialogueEventChannel DialogueEventChannel;
    [SerializeField] private string _dialoguePath;
    public void Interact()
    {
        DialogueEventChannel.SetCurrentPath(_dialoguePath);
        DialogueEventChannel.RaiseDialogueStartedEvent();
    }
}
