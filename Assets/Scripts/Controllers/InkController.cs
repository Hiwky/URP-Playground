using UnityEngine;
using System;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class InkController : MonoBehaviour
{
	[SerializeField]
	private TextAsset inkJSONAsset = null;
	public Story story;

	[SerializeField]
	private Canvas canvas = null;

	public static event Action<Story> OnCreateStory;
	public StringSO dialogText;
	[SerializeField]
	private GameObject choicePanel;
	[SerializeField]
	private IntSO choiceIndex;
	[SerializeField]
	private SimpleChoiceListSO simpleChoiceList;

    private void Awake()
    {
		choiceIndex.OnChanged += OnChooseChoice;
    }
    void Start()
	{
		// Remove the default message
		//RemoveChildren();
		StartStory();
	}

	// Creates a new Story object with the compiled story which we can then play!
	void StartStory()
	{
		story = new Story(inkJSONAsset.text);
		if (OnCreateStory != null) OnCreateStory(story);
		RefreshView();
	}

	public void ProgressStory(InputAction.CallbackContext context)
    {
		Debug.Log("Continue pressed.");
		//if (story.canContinue)
  //      {
		//	//display a line of text
		//	string text = story.Continue();
		//	text = text.Trim();
		//	dialogText.Value = text;
  //      }
		//else if (story.currentChoices.Count > 0)
  //      {
		//	for (int i = 0; i < story.currentChoices.Count; i++)
		//	{

		//	}
		//}
		//else
  //      {
		//	//end dialog
  //      }
    }

	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void RefreshView()
	{
		dialogText.Value = "";
		// Read all the content until we can't continue any more
		while (story.canContinue)
		{
			// Continue gets the next line of the story
			string text = story.Continue();
			// This removes any white space from the text.
			text = text.Trim();
			dialogText.Value += text;
			// Display the text on screen!
			//CreateContentView(text);
		}

		// Display all the choices, if there are any!
		if (story.currentChoices.Count > 0)
		{
			simpleChoiceList.Value.Clear();
			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				simpleChoiceList.Value.Add(new SimpleChoice(story.currentChoices[i].index, story.currentChoices[i].text));
			}
			simpleChoiceList.UpdateChoices();
		}
		// If we've read all the content and there's no choices, the story is finished!
		else
		{

		}
	}

	void OnChooseChoice(int selectedChoice)
    {
		story.ChooseChoiceIndex(selectedChoice);
		RefreshView();
	}
}
