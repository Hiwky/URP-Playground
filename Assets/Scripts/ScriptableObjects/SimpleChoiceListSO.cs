using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Variables/Simple Choice List", fileName = "Simple Choice List")]
public class SimpleChoiceListSO : VariableSO<List<SimpleChoice>>
{
    public event Action OnChoicesUpdated;

    public void UpdateChoices()
    {
        OnChoicesUpdated?.Invoke();
    }
}
