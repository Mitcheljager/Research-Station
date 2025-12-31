using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour {
    public Screen screen;
    public Vector2 minSize = new(200, 150);
    public RectTransform rectTransform;
    public ScrollRect scrollRect;

    [Header("Resize")]
    public ResizeHandle[] resizeHandles;

    [Header("State")]
    public bool isMaximized = false;
}
