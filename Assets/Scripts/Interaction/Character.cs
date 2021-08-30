using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IInteractive
{
    [Header("Event Channels")]
    [SerializeField] private DialogueEventChannel DialogueEventChannel;
    [SerializeField] private InteractionEventChannel InteractionEventChannel;

    [SerializeField] private string _dialoguePath;

    [SerializeField] private GameObject _defaultCamera;
    [SerializeField] private GameObject _faceCamera;

    public void Interact()
    {
        DialogueEventChannel.SetCurrentPath(_dialoguePath);
        SubscribeToInteractions();
        DialogueEventChannel.RaiseDialogueStartedEvent();
        _defaultCamera.SetActive(true);
    }

    private void SubscribeToInteractions()
    {
        InteractionEventChannel.OnChangeCamera += ChangeCamera;
        InteractionEventChannel.OnInteractionEnd += UnsubscribeFromInteractions;
    }

    private void UnsubscribeFromInteractions()
    {
        InteractionEventChannel.OnChangeCamera -= ChangeCamera;
        _defaultCamera.SetActive(false);
        _faceCamera.SetActive(false);
    }

    private void ChangeCamera(string cameraName)
    {
        Debug.Log($"Switching camera to {cameraName}");
        switch (cameraName)
        {
            case "default":
                _faceCamera.SetActive(false);
                _defaultCamera.SetActive(true);
                break;
            case "face":
                _defaultCamera.SetActive(false);
                _faceCamera.SetActive(true);
                break;
        }
    }


}
