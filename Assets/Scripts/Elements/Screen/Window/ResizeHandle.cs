using UnityEngine;
using UnityEngine.EventSystems;

public class ResizeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler {
    public enum HandleType {
        Left, Right, Top, Bottom,
        TopLeft, TopRight, BottomRight, BottomLeft
    }

    public HandleType type;
    public Window window;

    private CursorManager cursorManager;
    private Vector2 startMousePosition;
    private Vector2 startSize;
    private Vector2 startPosition;

    void Start() {
        cursorManager = FindFirstObjectByType<CursorManager>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        RectTransform parent = window.rectTransform.parent as RectTransform;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, eventData.position, eventData.pressEventCamera, out startMousePosition);

        startSize = window.rectTransform.sizeDelta;
        startPosition = window.rectTransform.anchoredPosition;

        cursorManager.SetCursorDownTransform(transform);
    }

    public void OnDrag(PointerEventData eventData) {
        RectTransform parent = window.rectTransform.parent as RectTransform;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, eventData.position, eventData.pressEventCamera, out Vector2 currentMousePosition);

        Vector2 delta = currentMousePosition - startMousePosition;

        Vector2 size = startSize;
        Vector2 position = startPosition;

        // Horizontal
        if (type == HandleType.Left || type == HandleType.TopLeft || type == HandleType.BottomLeft) {
            float width = Mathf.Max(startSize.x - delta.x, window.minSize.x);
            float difference = width - startSize.x;

            size.x = width;
            position.x = startPosition.x - difference;
        } else if (type == HandleType.Right || type == HandleType.TopRight || type == HandleType.BottomRight) {
            size.x = Mathf.Max(startSize.x + delta.x, window.minSize.x);
        }

        // Vertical
        if (type == HandleType.Top || type == HandleType.TopLeft || type == HandleType.TopRight) {
            float height = Mathf.Max(startSize.y + delta.y, window.minSize.y);
            float difference = height - startSize.y;

            size.y = height;
            position.y = startPosition.y + difference;
        } else if (type == HandleType.Bottom || type == HandleType.BottomLeft || type == HandleType.BottomRight) {
            size.y = Mathf.Max(startSize.y - delta.y, window.minSize.y);
        }

        window.rectTransform.sizeDelta = size;
        window.rectTransform.anchoredPosition = position;
    }
}
