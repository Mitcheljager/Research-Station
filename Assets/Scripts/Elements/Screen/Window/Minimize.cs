using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Minimize : MonoBehaviour {
    public Window window;

    void OnEnable() {
        WindowEvent.OnMinimizeWindow += ToggleMinimize;
    }

    void OnDisable() {
        WindowEvent.OnMinimizeWindow -= ToggleMinimize;
    }

    public void ToggleMinimize(Window eventWindow) {
        if (eventWindow != window) return;

        window.isMinimized = !window.isMinimized;
        window.isFocused = !window.isMinimized;

        if (window.isMinimized) {
            window.transform.localScale = Vector3.zero;
        } else {
            window.transform.localScale = Vector3.one;
        }

        WindowEvent.UpdateWindow(window);
    }
}
