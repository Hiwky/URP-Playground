using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameStateSO State;
    [SerializeField]
    private DialogueEventChannel DialogueEventChannel;
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        DialogueEventChannel.OnDialogueStarted += SetStateDialogue;
        DialogueEventChannel.OnDialogueEnded += SetStateGameplay;
    }

    public void SetStateGameplay()
    {
        State.UpdateGameState(GameState.Gameplay);
    }

    public void SetStateDialogue()
    {
        State.UpdateGameState(GameState.Dialogue);
    }
}
