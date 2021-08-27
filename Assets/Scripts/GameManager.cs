using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameStateSO State;
    [SerializeField] private DialogueEventChannel DialogueEventChannel;

    void Start()
    {
        DialogueEventChannel.OnDialogueStarted += SetStateDialogue;
        DialogueEventChannel.OnDialogueEnded += SetStateGameplay;
        QualitySettings.vSyncCount = 1;
    }

    public void SetStateGameplay()
    {
        State.UpdateGameState(GameState.Gameplay);
    }

    public void SetStateDialogue()
    {
        State.UpdateGameState(GameState.Dialogue);
    }

    public void SetStatePause()
    {
        State.UpdateGameState(GameState.Pause);
    }

}
