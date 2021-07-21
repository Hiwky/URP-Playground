using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSO<T> : ScriptableObject
{
    public event Action<T> OnChanged;

    [SerializeField]
    private T _value;

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            OnChanged?.Invoke(_value);
        }
    }


}
