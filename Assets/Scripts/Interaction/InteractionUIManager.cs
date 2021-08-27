using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUIManager : MonoBehaviour
{
    [SerializeField] private Image interactImage;
    [SerializeField] private DialogueEventChannel DialogueEventChannel;
    [SerializeField] private InteractionTypeSO InteractionType;

    private void Start()
    {
        InteractionType.OnChanged += ToggleImage;
        DialogueEventChannel.OnDialogueStarted += DisablePrompt;
        DialogueEventChannel.OnDialogueEnded += EnablePrompt;
    }

    private void ToggleImage(InteractionTypes interaction)
    {
        switch (interaction)
        {
            case InteractionTypes.None:
                interactImage.enabled = false;
                break;
            case InteractionTypes.Talk:
                interactImage.enabled = true;
                break;
        }
    }

    private void EnablePrompt()
    {
        interactImage.enabled = true;
    }

    private void DisablePrompt()
    {
        interactImage.enabled = false;
    }
}
