using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventOnClick : MonoBehaviour, IPointerClickHandler {
    public UnityEvent assignedEvent;

    public void OnPointerClick(PointerEventData eventData) {
        assignedEvent.Invoke();
    }
}
