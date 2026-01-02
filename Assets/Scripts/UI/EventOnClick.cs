using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EventOnClick : MonoBehaviour, IPointerClickHandler {
    public UnityEvent assignedEvent;
    public bool bubble = true;
    public bool requireDoubleClick = false;

    private readonly float doubleClickPeriodSeconds = 0.4f;
    private bool isWithinDoubleClickPeriod = false;

    void Update() {
        if (!bubble) return;
        if (!Mouse.current.leftButton.wasReleasedThisFrame) return;

        PointerEventData eventData = new(EventSystem.current) { position = Pointer.current.position.ReadValue() };
        System.Collections.Generic.List<RaycastResult> results = new();
        EventSystem.current.RaycastAll(eventData, results);

        if (results.Exists(r => r.gameObject.transform.IsChildOf(transform))) {
            Click();
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (bubble) return;

        Click();
    }

    private void Click() {
        if (requireDoubleClick && !isWithinDoubleClickPeriod) {
            StartCoroutine(SetDoubleClickPeriod());
            return;
        }

        assignedEvent.Invoke();
    }

    private IEnumerator SetDoubleClickPeriod() {
        isWithinDoubleClickPeriod = true;

        yield return new WaitForSeconds(doubleClickPeriodSeconds);

        isWithinDoubleClickPeriod = false;
    }
}
