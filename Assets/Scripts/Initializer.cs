using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive).completed += LoadMainMenu;
    }

    private void LoadMainMenu(AsyncOperation obj)
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive).completed += UnloadThis;
    }

    private void UnloadThis(AsyncOperation obj)
    {
        SceneManager.UnloadSceneAsync(0);
    }
}
