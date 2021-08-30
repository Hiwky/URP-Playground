using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "InteractionEventChannel", menuName = "Scriptable Objects/Event Channels/InteractionEventChannel")]
public class InteractionEventChannel : ScriptableObject
{
    public event Action<string> OnChangeCamera;
    public event Action OnInteractionEnd;

    public void RaiseChangeCameraEvent(string cameraName)
    {
        OnChangeCamera?.Invoke(cameraName);
    }

    public void RaiseInteractionEndEvent()
    {
        OnInteractionEnd?.Invoke();
    }
}
