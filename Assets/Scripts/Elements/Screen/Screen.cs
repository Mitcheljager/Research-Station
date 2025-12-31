using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour {
    public Canvas canvas;
    public RectTransform topBarRectTransform;
    public RectTransform contentAreaRectTransform;

    public List<Window> activeWindows = new();

    void Start() {
        foreach(Window window in canvas.transform.GetComponentsInChildren<Window>()) {
            window.screen = this;
            activeWindows.Add(window);
        }
    }
}
