using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DefaultSelector : MonoBehaviour
{
    private GameObject _selectedElement;
    private EventSystem _eventSystem;

    private void OnEnable()
    {
        _eventSystem = EventSystem.current;
    }
    // Update is called once per frame
    void Update()
    {
        if (_eventSystem.currentSelectedGameObject != null)
        {
            _selectedElement = _eventSystem.currentSelectedGameObject;
        }
        else
        {
            _eventSystem.SetSelectedGameObject(_selectedElement);
        }

    }
}
