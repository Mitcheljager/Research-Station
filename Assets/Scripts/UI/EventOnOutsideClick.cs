using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EventOnOutsideClick : MonoBehaviour {
    public UnityEvent assignedEvent;

    void Update() {
        if (!Mouse.current.leftButton.wasReleasedThisFrame) return;

        PointerEventData eventData = new(EventSystem.current) { position = Mouse.current.position.ReadValue() };

        List<RaycastResult> results = new();
        EventSystem.current.RaycastAll(eventData, results);

        bool clickedInside = false;

        foreach (RaycastResult result in results) {
            if (result.gameObject.transform.IsChildOf(transform)) {
                clickedInside = true;
                break;
            }
        }

        if (!clickedInside) assignedEvent.Invoke();
    }
}
