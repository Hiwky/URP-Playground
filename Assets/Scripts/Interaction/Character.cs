using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IInteractive
{
    [SerializeField]
    private TextAsset story;
    [SerializeField]
    private TextAssetSO currentStory;
    [SerializeField]
    private VoidEvent OnDialogStarted;
    [SerializeField]
    private DialogueEventChannel DialogueEventChannel;
    public void Interact()
    {
        Debug.Log("I got interected with!");
        currentStory.Value = story;
        //OnDialogStarted.Raise();
        DialogueEventChannel.RaiseDialogueStartedEvent();
    }
}
