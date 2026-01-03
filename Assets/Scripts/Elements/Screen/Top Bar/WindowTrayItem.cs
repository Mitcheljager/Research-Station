using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowTrayItem : MonoBehaviour {
    public Window window;
    public Image activeBackground;
    public Image regularBackground;
    public Image focusIndicator;

    void OnEnable() {
        WindowEvent.OnFocusWindow += SetFocusState;
        WindowEvent.OnBlurWindow += SetFocusState;
    }

    void OnDisable() {
        WindowEvent.OnFocusWindow -= SetFocusState;
        WindowEvent.OnBlurWindow -= SetFocusState;
    }

    public void SetFocusState(Window _) {
        focusIndicator.gameObject.SetActive(window.isFocused);
    }

    public void SetMinimizeState() {
        activeBackground.gameObject.SetActive(!window.isMinimized);
    }

    public void OnClick() {
        if (window.isMinimized || window.isFocused) {
            WindowEvent.MinimizeWindow(window);
        }

        if (!window.isMinimized) {
            StartCoroutine(DelayFocus());
        }
    }

    private IEnumerator DelayFocus() {
        yield return new WaitForEndOfFrame();

        WindowEvent.FocusWindow(window);
    }
}
