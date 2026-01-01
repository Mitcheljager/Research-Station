using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EventOnClick : MonoBehaviour, IPointerClickHandler {
    public UnityEvent assignedEvent;
    public bool bubble = true;

    void Update() {
        if (!bubble) return;
        if (!Mouse.current.leftButton.wasReleasedThisFrame) return;

        PointerEventData eventData = new(EventSystem.current) { position = Pointer.current.position.ReadValue() };
        System.Collections.Generic.List<RaycastResult> results = new();
        EventSystem.current.RaycastAll(eventData, results);

        if (results.Exists(r => r.gameObject.transform.IsChildOf(transform))) {
            assignedEvent.Invoke();
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (bubble) return;
        assignedEvent.Invoke();
    }
}
