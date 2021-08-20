using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUIManager : MonoBehaviour
{
    [SerializeField]
    private Image interactImage;
    [SerializeField]
    private DialogueEventChannel DialogueEventChannel;
    [SerializeField]
    private InteractionTypeSO InteractionType;

    private Canvas _canvas;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
        InteractionType.OnChanged += ToggleImage;
        DialogueEventChannel.OnDialogueStarted += DisableCanvas;
        DialogueEventChannel.OnDialogueEnded += EnableCanvas;
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

    private void EnableCanvas()
    {
        _canvas.enabled = true;
    }

    private void DisableCanvas()
    {
        _canvas.enabled = false;
    }
}
