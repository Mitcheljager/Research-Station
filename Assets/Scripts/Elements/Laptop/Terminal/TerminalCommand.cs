using System.Collections.Generic;

public interface ITerminalCommandParameters {
    Dictionary<string, string> Parameters { get; set; }

    public void Add(string key, string value) {
        Parameters[key] = value;
    }
}

public interface ITerminalCommand {
    string Name { get; }

    void Execute(ITerminalCommandParameters parameters);
}

public class TerminalCommandParameters : ITerminalCommandParameters {
    public Dictionary<string, string> Parameters { get; set; } = new();
}
