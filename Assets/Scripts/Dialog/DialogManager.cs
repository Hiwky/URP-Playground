using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour
{
    public StringSO dialogText;
    public StringSO nameText;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI characterName;
    [SerializeField]
    private Button buttonPrefab = null;
    [SerializeField]
    private GameObject choicePanel;
    [SerializeField]
    private GameObject namePanel;
    [SerializeField]
    private IntSO choiceIndex;
    [SerializeField]
    private SimpleChoiceListSO choiceList;

    private 
    // Start is called before the first frame update
    void Awake()
    {
        dialogText.OnChanged += DialogChanged;
        nameText.OnChanged += NameChanged;
        choiceList.OnChoicesUpdated += CreateChoices;
    }

    private void DialogChanged(string dialog)
    {
        text.text = dialog;
    }

    private void NameChanged(string newName)
    {
        if (newName.Length > 0)
        {
            namePanel.SetActive(true);
            characterName.text = newName;
        } else
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

            button.onClick.AddListener(delegate {
                OnChooseChoice(choice.index);
            });
        }

    }

    Button CreateChoiceButton(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(choicePanel.transform, false);

        // Gets the text from the button prefab
        TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
        choiceText.text = text;

        return choice;
    }

    void OnChooseChoice(int selectedChoice)
    {
        choiceIndex.Value = selectedChoice;
        EventSystem.current.SetSelectedGameObject(null);
        RemoveChoices();
        choicePanel.SetActive(false);
    }

    void RemoveChoices()
    {
        int childCount = choicePanel.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(choicePanel.transform.GetChild(i).gameObject);
        }
    }
}
