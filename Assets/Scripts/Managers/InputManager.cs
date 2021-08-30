using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField]
    private GameInputSO input;
    [SerializeField]
    private VoidEvent OnDialogStarted;

    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;

    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = false;
    public bool cursorInputForLook = false;

    private void OnEnable()
    {
        input.input.Enable();
        input.input.Test.Test.performed += StartDialog;
    }

    private void OnDisable()
    {
        input.input.Disable();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }

    private void StartDialog(InputAction.CallbackContext context)
    {
        OnDialogStarted.Raise();
    }

    public void EnableUI()
    {
        input.input.UI.Enable();
        input.input.Player.Disable();
    }

    public void EnablePlayer()
    {
        input.input.UI.Disable();
        input.input.Player.Enable();
    }

    public void DisableAll()
    {
        input.input.UI.Disable();
        input.input.Player.Disable();
    }

    #region Actions
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        if (cursorInputForLook)
        {
            LookInput(value.Get<Vector2>());
        }
    }

    public void OnJump(InputValue value)
    {
        JumpInput(value.isPressed);
    }

    public void OnSprint(InputValue value)
    {
        SprintInput(value.isPressed);
    }


    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    }

    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }

    public void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }

    public void SprintInput(bool newSprintState)
    {
        sprint = newSprintState;
    }
    #endregion
}
