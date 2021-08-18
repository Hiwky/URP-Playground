using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Gameplay,// regular state: player moves, attacks, can perform actions
    Pause,// pause menu is opened, the whole game world is frozen
    Dialogue,
    Cutscene,
}

//[CreateAssetMenu(fileName = "GameState", menuName = "Gameplay/GameState", order = 51)]
public class GameStateSO : ScriptableObject
{
    public event Action<GameState> OnChanged;

    [SerializeField]
    private GameState _currentGameState = default;
    private GameState _previousGameState = default;
    public GameState CurrentGameState => CurrentGameState;

    public void UpdateGameState(GameState newGameState)
    {
        _previousGameState = _currentGameState;
        _currentGameState = newGameState;
        OnChanged?.Invoke(_currentGameState);

    }
    public void ResetToPreviousGameState()
    {
        _currentGameState = _previousGameState;

    }

}