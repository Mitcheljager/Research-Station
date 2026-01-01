using System;
using UnityEngine;

public static class WindowEvent {
    public static event Action<Window> OnUpdateWindow;
    public static event Action<Window> OnCloseWindow;

    public static void UpdateWindow(Window window) {
        OnUpdateWindow?.Invoke(window);
    }

    public static void CloseWindow(Window window) {
        OnCloseWindow?.Invoke(window);
    }
}
