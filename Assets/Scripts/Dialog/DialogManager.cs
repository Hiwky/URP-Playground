using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DialogManager : MonoBehaviour
{
    public StringSO dialogText;
    public StringSO nameText;
    [SerializeField]
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Awake()
    {
        dialogText.OnChanged += DialogChanged;
    }

    private void DialogChanged(string dialog)
    {
        text.text = dialog;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
