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

    private void Start()
    {
        DialogueEventChannel.OnDialogueStarted += ToggleImage;
    }

    public void ToggleImage()
    {
        interactImage.enabled = !interactImage.enabled;
    }
}
