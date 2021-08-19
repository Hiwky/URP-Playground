using UnityEngine;
using System;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class InkController : MonoBehaviour
{
	[SerializeField]
	private TextAssetSO currentStory;
	public Story story;

	public static event Action<Story> OnCreateStory;
	[SerializeField]
	private StringSO dialogueText;
	[SerializeField]
	private StringSO nameText;
	[SerializeField]
	private IntSO choiceIndex;
	[SerializeField]
	private SimpleChoiceListSO simpleChoiceList;
	[SerializeField]
	private VoidEvent OnDialogueEnded;
	[SerializeField]
	private DialogueEventChannel DialogueEventChannel;

	[SerializeField]
	private GameStateSO State;

	private bool waitingForChoice = false;

    private void Awake()
    {
		choiceIndex.OnChanged += OnChooseChoice;
		currentStory.OnChanged += StartNewStory;
    }

    private void StartNewStory(TextAsset newStory)
    {
		story = new Story(newStory.text);
		if (OnCreateStory != null) OnCreateStory(story);
		ProgressStory();
	}

	// Creates a new Story object with the compiled story which we can then play!
	public void StartStory(TextAsset storyJson)
	{
		story = new Story(storyJson.text);
		if (OnCreateStory != null) OnCreateStory(story);
		ProgressStory();
	}

	public void ProgressStory()
    {
        if (story.canContinue)
        {
            string text = story.Continue();
            text = text.Trim();
            dialogueText.Value = text;
			if (story.currentTags.Count > 0)
			{
				nameText.Value = story.currentTags[0];
			}
			else
            {
				nameText.Value = "";
            }
        }
        else if (story.currentChoices.Count > 0)
        {
			simpleChoiceList.Value.Clear();
			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				simpleChoiceList.Value.Add(new SimpleChoice(story.currentChoices[i].index, story.currentChoices[i].text));
			}
			simpleChoiceList.UpdateChoices();
			waitingForChoice = true;
        }
        else
        {
			DialogueEventChannel.RaiseDialogueEndedEvent();
			//OnDialogueEnded.Raise();
			State.UpdateGameState(GameState.Gameplay);
        }
    }

	public void OnSubmit(InputAction.CallbackContext context)
    {
		if (waitingForChoice)
			return;
		ProgressStory();
    }

	void OnChooseChoice(int selectedChoice)
    {
		waitingForChoice = false;
		story.ChooseChoiceIndex(selectedChoice);
		ProgressStory();
	}
}
