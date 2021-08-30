using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseSelector : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!EventSystem.current.alreadySelecting)
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject);
        }
    }
}
