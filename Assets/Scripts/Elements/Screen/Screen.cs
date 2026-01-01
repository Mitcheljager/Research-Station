using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour {
    public Canvas canvas;
    public RectTransform topBarRectTransform;
    public RectTransform contentAreaRectTransform;
    public WindowTray windowTray;

    public List<Window> activeWindows = new();

    void OnEnable() {
        WindowEvent.OnCloseWindow += DestroyActiveWindow;
    }

    void OnDisable() {
        WindowEvent.OnCloseWindow -= DestroyActiveWindow;
    }

    void Awake() {
        foreach(Window window in canvas.transform.GetComponentsInChildren<Window>()) {
            window.screen = this;
            activeWindows.Add(window);
        }
    }

    private void DestroyActiveWindow(Window window) {
        activeWindows.Remove(window);

        Destroy(window.gameObject);

        WindowEvent.UpdateWindow(window);
    }
}
