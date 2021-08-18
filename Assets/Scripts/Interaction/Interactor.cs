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
       // Debug.Log($"Collided with {other.gameObject.name}");
        _enterZone.Invoke(true, other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log($"Collision with {other.gameObject.name} ended");
        _enterZone.Invoke(false, other.gameObject);
    }
}
