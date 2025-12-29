using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour {
    private readonly Dictionary<string, ITerminalCommand> commands = new();

    void Start() {
        Register(new TestTerminalCommand());
    }

    void OnEnable() {
        TerminalEvent.OnExecuteCommand += Run;
    }

    void OnDisable() {
        TerminalEvent.OnExecuteCommand -= Run;
    }

    private void Register(ITerminalCommand command) {
        commands[command.Name.ToLower()] = command;
    }

    private void Run(string input) {
        string[] splitInput = input.Split(' ');
        string commandName = splitInput[0].ToLower();

        if (commandName.Length == 0) return;

        ITerminalCommand command = ParseCommand(commandName);

        if (command == null) {
            TerminalEvent.AddToStream($"Unknown command: {commandName}");
            return;
        }

        string parametersString = splitInput.Length > 1 ? string.Join(" ", splitInput[1..]) : "";

        ITerminalCommandParameters parameters = ParseCommandParameters(parametersString);

        command.Execute(parameters);
    }

    private ITerminalCommand ParseCommand(string commandName) {
        if (commands.TryGetValue(commandName, out ITerminalCommand command)) {
            return command;
        }

        return null;
    }

    private ITerminalCommandParameters ParseCommandParameters(string parametersString) {
        ITerminalCommandParameters parametersDictionary = new TerminalCommandParameters();

        string[] splitParameters = parametersString.Split(" ");
        char[] charsToTrim = { ' ', '\n', '\t' };

        int valuelessParameterIndex = 0;

        foreach(string parameter in splitParameters) {
            string parameterTrimmed = parameter.Trim(charsToTrim);
            int separatorIndex = parameterTrimmed.IndexOf('=');

            if (separatorIndex == -1) {
                parametersDictionary.Add(valuelessParameterIndex.ToString(), parameter);
                valuelessParameterIndex++;
                continue;
            }

            string key = parameterTrimmed[..separatorIndex].Trim(charsToTrim);
            string value = parameterTrimmed[(separatorIndex + 1)..].Trim(charsToTrim);

            parametersDictionary.Add(key, value);
        }

        return parametersDictionary;
    }
}
