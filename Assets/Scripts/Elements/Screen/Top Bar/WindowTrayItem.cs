using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowTrayItem : MonoBehaviour {
    public Window window;
    public Image focusBackground;
    public Image regularBackground;
    public Image activeIndicator;
    public Minimize minimize;

    public void SetFocus(bool state) {
        focusBackground.gameObject.SetActive(state);
    }

    public void SetMinimized() {
        activeIndicator.gameObject.SetActive(!window.isMinimized);

        SetFocus(!window.isMinimized);
    }
}
