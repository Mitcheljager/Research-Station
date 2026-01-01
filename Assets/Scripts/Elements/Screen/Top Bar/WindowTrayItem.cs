using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowTrayItem : MonoBehaviour {
    public Window window;
    public Image activeBackground;
    public Image regularBackground;
    public Image focusIndicator;
    public Minimize minimize;

    public void SetFocus() {
        focusIndicator.gameObject.SetActive(window.isFocused);
    }

    public void SetMinimized() {
        activeBackground.gameObject.SetActive(!window.isMinimized);
    }
}
