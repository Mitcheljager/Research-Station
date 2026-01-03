using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler {
    public Window window;

    private RectTransform rectTransform;
    private Screen screen;
    private Vector2 offset;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        screen = GetComponentInParent<Screen>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (window.isMaximized) return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(window.rectTransform, eventData.position, eventData.pressEventCamera, out offset);
        window.Focus();
    }

    public void OnDrag(PointerEventData eventData) {
        if (window.isMaximized) return;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(window.rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out var localPoint)) {
            Vector3 newPosition = localPoint - offset;

            Rect parentRect = screen.contentAreaRectTransform.rect;
            float parentTop = parentRect.yMax;
            float parentLeft = parentRect.xMin;
            float parentHeight = parentRect.height;
            float parentWidth = parentRect.width;

            float dragHandleHeight = rectTransform.rect.height;

            float windowTop = newPosition.y + rectTransform.rect.yMax;
            float windowLeft = newPosition.x;
            float windowWidth = window.rectTransform.rect.width;

            newPosition.y = Mathf.Clamp(newPosition.y, parentHeight * -1 + dragHandleHeight, newPosition.y - windowTop - parentTop);
            newPosition.x = Mathf.Clamp(newPosition.x, newPosition.x - windowLeft - parentLeft, parentWidth - windowWidth);

            window.rectTransform.localPosition = newPosition;
        }
    }
}
