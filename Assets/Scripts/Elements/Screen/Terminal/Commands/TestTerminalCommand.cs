using UnityEngine;

public class TestTerminalCommand : ITerminalCommand {
    public string Name => "test";

    public void Execute(ITerminalCommandParameters parameters) {
        foreach (var parameter in parameters.Parameters) {
            Debug.Log($"{parameter.Key}: {parameter.Value}");
        }

        parameters.Parameters.TryGetValue("type", out string type);

        if (!parameters.Parameters.TryGetValue("0", out string message)) {
            message = "No message given";
        }

        if (type == "warn") {
            TerminalEvent.AddToStream($"<color=#ffff00>{message}</color>");
        } else if (type == "error") {
            TerminalEvent.AddToStream($"<color=#ff0000>{message}</color>");
        } else {
            TerminalEvent.AddToStream(message);
        }
    }
}
