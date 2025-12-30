using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler {
    public Window window;

    private Vector2 offset;

    public void OnBeginDrag(PointerEventData eventData) {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(window.rectTransform, eventData.position, eventData.pressEventCamera, out offset);
    }

    public void OnDrag(PointerEventData eventData) {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(window.rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out var localPoint)) {
            window.rectTransform.localPosition = localPoint - offset;
        }
    }
}
