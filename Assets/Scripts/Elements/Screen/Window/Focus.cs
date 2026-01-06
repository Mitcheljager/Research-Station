using UnityEngine;

[RequireComponent(typeof(Window))]
public class Focus : MonoBehaviour {
    private Window window;

    void Awake() {
        window = GetComponent<Window>();
    }

    void OnEnable() {
        WindowEvent.OnFocusWindow += ChangeFocus;
    }

    void OnDisable() {
        WindowEvent.OnFocusWindow -= ChangeFocus;
    }

    public void Blur() {
        ChangeFocus(null);

        WindowEvent.BlurWindow(window);
    }

    public void ChangeFocus(Window eventWindow) {
        if (eventWindow == null && !window.isFocused) return;

        window.isFocused = eventWindow == window;

        if (!window.isFocused) return;
        if (eventWindow == null) return;

        window.rectTransform.SetAsLastSibling();
    }
}
