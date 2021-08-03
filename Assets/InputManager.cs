using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameInputSO input;
    [SerializeField]
    private VoidEvent OnDialogStarted;

    private void OnEnable()
    {
        input.instance.Enable();
        input.instance.UI.Test.performed += StartDialog;
    }

    private void OnDisable()
    {
        input.instance.Disable();
    }

    private void StartDialog(InputAction.CallbackContext context)
    {
        Debug.Log("Dialog started");
        OnDialogStarted.Raise();
    }
}
