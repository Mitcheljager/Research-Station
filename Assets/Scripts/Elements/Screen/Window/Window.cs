using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour {
    public Vector2 minSize = new(200, 150);
    public RectTransform rectTransform;
    public ScrollRect scrollRect;

    [Header("Fluff")]
    public string windowName;
    public Sprite iconSprite;
    public bool allowMultiple = false;

    [Header("Resize")]
    public ResizeHandle[] resizeHandles;

    [Header("State")]
    [Fade] public Screen screen;
    [Fade] public bool isMaximized = false;
    [Fade] public bool isMinimized = false;
    [Fade] public bool isFocused = false;
}
