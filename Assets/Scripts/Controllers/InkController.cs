using UnityEngine;
using System;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;

public class InkController : MonoBehaviour
{
	private const string DEFAULT_PATH = "default_knot";	
	public static event Action<Story> OnCreateStory;

	public Story story;

	[SerializeField] private TextAsset _currentStory;
	[SerializeField] private StringSO dialogueText;
	[SerializeField] private StringSO nameText;
	[SerializeField] private IntSO choiceIndex;
	[SerializeField] private SimpleChoiceListSO simpleChoiceList;
	[SerializeField] private VoidEvent OnDialogueEnded;
	[SerializeField] private GameStateSO State;

	[Header("Event Channels")]
	[SerializeField] private DialogueEventChannel DialogueEventChannel;
	[SerializeField] private SaveLoadEventChannel SaveLoadEventChannel;
	[SerializeField] private InteractionEventChannel InteractionEventChannel;

	private string _saveData;
	private bool waitingForChoice = false;

    private void Awake()
    {
    }

    private void Start()
    {
		choiceIndex.OnChanged += OnChooseChoice;
		DialogueEventChannel.OnDialogueStarted += StartAtCurrentPath;
		SaveLoadEventChannel.OnDataReadyToLoad += LoadStoryData;
		SaveLoadEventChannel.OnRequestSaveData += SaveStoryData;
		StartNewStory(_currentStory);
	}

    private void StartNewStory(TextAsset newStory)
    {
		story = new Story(newStory.text);
		// Ink method to update story in editor
		if (OnCreateStory != null) OnCreateStory(story);

		BindExternalFunctions();
	}

	private void StartAtCurrentPath()
    {
		StartAtPath(DialogueEventChannel.GetCurrentPath());
    }

	private void StartAtPath(string pathName)
    {
		if (pathName.Length == 0)
		{
			pathName = DEFAULT_PATH;
		}
		story.ChoosePathString(pathName);
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
			InteractionEventChannel.RaiseInteractionEndEvent();
			//OnDialogueEnded.Raise();
			State.UpdateGameState(GameState.Gameplay);
			_saveData = story.state.ToJson();
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

	private void SaveStoryData()
    {
		SaveLoadEventChannel.CurrentSaveData.storyData = story.state.ToJson();
		SaveLoadEventChannel.RaiseDataReadyToSave();
    }

	private void LoadStoryData()
    {
		story.state.LoadJson(SaveLoadEventChannel.CurrentSaveData.storyData);
    }

	private void BindExternalFunctions()
    {
		story.BindExternalFunction("LogLine", (string text) =>
		{
			Debug.Log(text);
		});

		story.BindExternalFunction("Camera", (string cameraName) =>
		{
			InteractionEventChannel.RaiseChangeCameraEvent(cameraName);
		});

	}
}
