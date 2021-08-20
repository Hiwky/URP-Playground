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
    private DialogueEventChannel DialogueEventChannel;
    public void Interact()
    {
        currentStory.Value = story;
        DialogueEventChannel.RaiseDialogueStartedEvent();
    }
}
