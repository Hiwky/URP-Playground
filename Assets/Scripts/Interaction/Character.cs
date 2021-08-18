using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IInteractive
{
    public void Interact()
    {
        Debug.Log("I got interected with!");
    }
}
