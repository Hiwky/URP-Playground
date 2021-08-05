using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConversation : MonoBehaviour, IGameEventListener<Void>
{
    [SerializeField]
    private TextAsset story;
    [SerializeField]
    private TextAssetSO currentStory;
    [SerializeField]
    private VoidEvent OnDialogStarted;

    private void OnEnable()
    {
        OnDialogStarted.RegisterListener(this);
    }

    private void OnDisable()
    {
        OnDialogStarted.UnregisterListener(this);
    }

    public void OnEventRaised(Void item)
    {
        currentStory.Value = story;
    }
}
