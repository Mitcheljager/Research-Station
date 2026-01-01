using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Minimize : MonoBehaviour {
    public Window window;

    public void ToggleMinimize() {
        window.isMinimized = !window.isMinimized;
        window.isFocused = !window.isMinimized;

        window.gameObject.SetActive(!window.isMinimized);

        WindowEvent.UpdateWindow(window);
    }
}
