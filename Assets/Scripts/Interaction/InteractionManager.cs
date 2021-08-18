using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
	[SerializeField]
	private VoidEvent ToggleInteractUI;
	[SerializeField]
	private GameInputSO Input;

	private GameObject _interactive = null;

    private void OnEnable()
    {
		Input.OnInteractPressed += Interact;
    }

    //Called by the Event on the trigger collider on the child GO called "InteractionDetector"
    public void OnTriggerChangeDetected(bool entered, GameObject obj)
	{
		if (entered)
			DisplayInteraction(obj);
		else
			RemoveInteraction();
	}

	private void DisplayInteraction(GameObject interactive)
    {
		ToggleInteractUI.Raise();
		_interactive = interactive;
	}

	private void RemoveInteraction()
    {
		ToggleInteractUI.Raise();
		_interactive = null;
	}

	private void Interact()
    {
		if (_interactive != null)
		{
			Debug.Log($"Interacting with {_interactive.name}");
		}
    }
}
