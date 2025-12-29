using System;

public static class TerminalEvents {
    public static event Action<string> OnExecuteCommand;

    public static void ExecuteCommand(string command) {
        OnExecuteCommand?.Invoke(command);
    }
}
