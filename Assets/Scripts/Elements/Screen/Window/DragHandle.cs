using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler {
    public Window window;

    private Vector2 offset;

    public void OnBeginDrag(PointerEventData eventData) {
        if (window.isMaximized) return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(window.rectTransform, eventData.position, eventData.pressEventCamera, out offset);
    }

    public void OnDrag(PointerEventData eventData) {
        if (window.isMaximized) return;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(window.rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out var localPoint)) {
            window.rectTransform.localPosition = localPoint - offset;
        }
    }
}
