using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Input", menuName = "Scriptable Objects/Game Input")]
public class GameInputSO : ScriptableObject
{
    public GameControls instance;
    private void OnEnable()
    {
        if (instance == null)
            instance = new GameControls();
    }
}
