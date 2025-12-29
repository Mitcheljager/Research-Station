using System;
using UnityEngine;

public static class TerminalEvent {
    public static event Action<string> OnExecuteCommand;
    public static event Action<string, float> OnAddToStream;

    public static void ExecuteCommand(string command) {
        OnExecuteCommand?.Invoke(command);
    }

    public static void AddToStream(string text, float delay = 0f) {
        OnAddToStream?.Invoke(text, delay);
    }
}
