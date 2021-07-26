using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    private IntSO choiceIndex;
    [SerializeField]
    private SimpleChoiceListSO choiceList;
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
            characterName.text = newName;
        }
    }

    private void CreateChoices()
    {
        for (int i = 0; i < choiceList.Value.Count; i++)
        {
            SimpleChoice choice = choiceList.Value[i];
            Button button = CreateChoiceView(choice.choiceText);

            button.onClick.AddListener(delegate {
                OnChooseChoice(choice.index);
            });
        }
        choicePanel.SetActive(true);
    }

    Button CreateChoiceView(string text)
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
