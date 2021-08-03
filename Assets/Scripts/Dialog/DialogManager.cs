using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private StringSO dialogText;
    [SerializeField]
    private StringSO nameText;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI characterName;
    [SerializeField]
    private Button buttonPrefab = null;
    [SerializeField]
    private GameObject dialogCanvas;
    [SerializeField]
    private GameObject choicePanel;
    [SerializeField]
    private GameObject namePanel;
    [SerializeField]
    private GameObject dialogPanel;
    [SerializeField]
    private IntSO choiceIndex;
    [SerializeField]
    private SimpleChoiceListSO choiceList;

    private void Awake()
    {
        dialogText.OnChanged += DialogChanged;
        nameText.OnChanged += NameChanged;
        choiceList.OnChoicesUpdated += CreateChoices;
    }

    private void DialogChanged(string dialog)
    {
        text.text = dialog;
        EventSystem.current.SetSelectedGameObject(dialogPanel);
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
        choicePanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(dialogPanel);
    }

    private void RemoveChoices()
    {
        int childCount = choicePanel.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            Destroy(choicePanel.transform.GetChild(i).gameObject);
        }
    }

    public void ToggleDialogCanvas()
    {
        dialogCanvas.SetActive(!dialogCanvas.activeInHierarchy);
    }
}
