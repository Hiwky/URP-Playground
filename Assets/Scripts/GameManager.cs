using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameStateSO State;
    // Start is called before the first frame update
    void Start()
    {
       SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
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
