using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private StringSO dialogueText;
    [SerializeField]
    private StringSO nameText;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI characterName;
    [SerializeField]
    private Button buttonPrefab = null;
    [SerializeField]
    private GameObject dialogueCanvas;
    [SerializeField]
    private GameObject choicePanel;
    [SerializeField]
    private GameObject namePanel;
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    private IntSO choiceIndex;
    [SerializeField]
    private SimpleChoiceListSO choiceList;

    private void Awake()
    {
        dialogueText.OnChanged += DialogueChanged;
        nameText.OnChanged += NameChanged;
        choiceList.OnChoicesUpdated += CreateChoices;
    }

    private void DialogueChanged(string dialogue)
    {
        text.text = dialogue;
        EventSystem.current.SetSelectedGameObject(dialoguePanel);
    }

    private void NameChanged(string newName)
    {
        if (newName.Length > 0)
        {
            namePanel.SetActive(true);
            characterName.text = newName;
        }
        else
        {
            namePanel.SetActive(false);
        }
    }

    private void CreateChoices()
    {
        choicePanel.SetActive(true);
        for (int i = 0; i < choiceList.Value.Count; i++)
        {
            SimpleChoice choice = choiceList.Value[i];
            Button button = CreateChoiceButton(choice.choiceText);
            if (i == 0)
                EventSystem.current.SetSelectedGameObject(button.gameObject);

            button.onClick.AddListener(delegate {
                OnChooseChoice(choice.index);
            });
        }
        dialoguePanel.GetComponent<Button>().interactable = false;
    }

    private Button CreateChoiceButton(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(choicePanel.transform, false);

        // Gets the text from the button prefab
        TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
        choiceText.text = text;

        return choice;
    }

    private void OnChooseChoice(int selectedChoice)
    {
        choiceIndex.Value = selectedChoice;
        EventSystem.current.SetSelectedGameObject(null);
        RemoveChoices();
        EventSystem.current.SetSelectedGameObject(dialoguePanel);
    }

    private void RemoveChoices()
    {
        int childCount = choicePanel.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            Destroy(choicePanel.transform.GetChild(i).gameObject);
        }
        choicePanel.SetActive(false);
        dialoguePanel.GetComponent<Button>().interactable = true;
    }

    public void StartDialogue()
    {
        ToggleDialogueCanvas(true);
    }

    public void EndDialogue()
    {
        RemoveChoices();
        ToggleDialogueCanvas(false);
    }

    public void ToggleInDialogue()
    {
        if (dialogueCanvas.activeInHierarchy)
            RemoveChoices();

        ToggleDialogueCanvas(!dialogueCanvas.activeInHierarchy);
    }

    public void ToggleDialogueCanvas(bool enabled)
    {
        dialogueCanvas.SetActive(enabled);
    }
}
