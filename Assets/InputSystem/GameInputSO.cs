using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Game Input", menuName = "Scriptable Objects/Game Input")]
public class GameInputSO : ScriptableObject, GameControls.IPlayerActions
{
    public GameControls input;
    [Header("Scriptable Objects")]
    [SerializeField]
    private VoidEvent OnDialogueStarted;
    [SerializeField]
    private GameStateSO State;

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

    [HideInInspector]
    public event Action OnInteractPressed;

    //private void OnApplicationFocus(bool hasFocus)
    //{
    //    SetCursorState(cursorLocked);
    //}

    private void OnEnable()
    {
        if (input == null)
            input = new GameControls();

        input.Enable();
        input.Test.Test.performed += StartDialogue;
        input.Player.SetCallbacks(this);
        SetCursorState(cursorLocked);
        State.OnChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        switch(state)
        {
            case GameState.Dialogue:
                EnableUI();
                break;
            case GameState.Gameplay:
                EnablePlayer();
                break;
        }
    }

    private void OnDisable()
    {
        DisableAll();
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }

    //temporary test method until I do interaction
    private void StartDialogue(InputAction.CallbackContext context)
    {
        OnDialogueStarted.Raise();
        State.UpdateGameState(GameState.Dialogue);
    }

    public void EnableUI()
    {
        input.UI.Enable();
        input.Player.Disable();
        SetCursorState(false);
    }

    public void EnablePlayer()
    {
        input.UI.Disable();
        input.Player.Enable();
        SetCursorState(true);
    }

    public void DisableAll()
    {
        input.UI.Disable();
        input.Player.Disable();
    }

    #region Actions
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput(context.ReadValue<Vector2>());
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        if (cursorInputForLook)
        {
            LookInput(context.ReadValue<Vector2>());
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        JumpInput(context.performed);
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                SprintInput(true);
                break;
            case InputActionPhase.Canceled:
                SprintInput(false);
                break;
        }
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

    public void OnInteract(InputAction.CallbackContext context)
    {
        OnInteractPressed.Invoke();
    }
    #endregion
}
