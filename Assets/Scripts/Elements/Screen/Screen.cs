using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour {
    public Canvas canvas;
    public RectTransform topBarRectTransform;
    public RectTransform contentAreaRectTransform;
    public WindowTray windowTray;

    public List<Window> activeWindows = new();

    void OnEnable() {
        WindowEvent.OnCreateWindow += CreateWindow;
        WindowEvent.OnDestroyWindow += DestroyActiveWindow;
    }

    void OnDisable() {
        WindowEvent.OnDestroyWindow -= DestroyActiveWindow;
    }

    void Awake() {
        foreach(Window window in canvas.transform.GetComponentsInChildren<Window>()) {
            window.screen = this;
            activeWindows.Add(window);
        }
    }

    private void CreateWindow(GameObject windowPrefab) {
        GameObject createdWindow = Instantiate(windowPrefab, contentAreaRectTransform.transform);

        Window window = createdWindow.GetComponent<Window>();
        window.AnimateIn();

        activeWindows.Add(window);

        WindowEvent.UpdateWindow(window);
        WindowEvent.FocusWindow(window);
    }

    private void DestroyActiveWindow(Window window) {
        activeWindows.Remove(window);

        Destroy(window.gameObject);

        WindowEvent.UpdateWindow(window);
    }
}
