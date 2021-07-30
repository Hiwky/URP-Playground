using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public GameInputSO input;
    // Start is called before the first frame update
    void Start()
    {
        input.instance.UI.Test.performed += TestMethod;
        input.instance.Enable();
    }

    void TestMethod(InputAction.CallbackContext context)
    {
        Debug.Log("Test works");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
