using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BoolEvent : UnityEvent<bool, GameObject>
{

}
public class Interactor : MonoBehaviour
{
    [SerializeField] private BoolEvent _enterZone = default;

    private void OnTriggerEnter(Collider other)
    {
        _enterZone.Invoke(true, other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        _enterZone.Invoke(false, other.gameObject);
    }
}
