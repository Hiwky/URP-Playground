using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUIManager : MonoBehaviour
{
    [SerializeField]
    private Image interactImage;

    public void ToggleImage()
    {
        interactImage.enabled = !interactImage.enabled;
    }
}
