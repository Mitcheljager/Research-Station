using System;
using UnityEngine;

public static class WindowEvent {
    public static event Action<GameObject> OnCreateWindow;
    public static event Action<Window> OnUpdateWindow;
    public static event Action<Window> OnDestroyWindow;
    public static event Action<Window> OnFocusWindow;
    public static event Action<Window> OnBlurWindow;
    public static event Action<Window> OnMinimizeWindow;

    public static void CreateWindow(GameObject windowPrefab) {
        OnCreateWindow?.Invoke(windowPrefab);
    }

    public static void UpdateWindow(Window window) {
        OnUpdateWindow?.Invoke(window);
    }

    public static void DestroyWindow(Window window) {
        OnDestroyWindow?.Invoke(window);
    }

    public static void FocusWindow(Window window) {
        OnFocusWindow?.Invoke(window);
    }

    public static void BlurWindow(Window window) {
        OnBlurWindow?.Invoke(window);
    }

    public static void MinimizeWindow(Window window) {
        OnMinimizeWindow?.Invoke(window);
    }
}
