using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour {
    public Vector2 minSize = new(200, 150);
    public RectTransform rectTransform;
    public ScrollRect scrollRect;

    [Header("Resize")]
    public ResizeHandle[] resizeHandles;

    [Header("State")]
    [Fade] public Screen screen;
    [Fade] public bool isMaximized = false;
    [Fade] public bool isMinimized = false;
    [Fade] public bool isFocused = false;

    void OnEnable() {
        WindowEvent.OnFocusWindow += ChangeFocus;
    }

    void OnDisable() {
        WindowEvent.OnFocusWindow -= ChangeFocus;
    }

    public void Blur() {
        ChangeFocus(null);

        WindowEvent.BlurWindow(this);
    }

    public void Focus() {
        ChangeFocus(this);

        WindowEvent.FocusWindow(this);
    }

    private void ChangeFocus(Window window) {
        if (window == null && !isFocused) return;

        isFocused = window == this;

        if (window != null) {
            if (isFocused) rectTransform.SetAsLastSibling();
            else rectTransform.SetAsFirstSibling();
        }
    }
}
