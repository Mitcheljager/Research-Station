using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TerminalInput : MonoBehaviour {
    public TMP_InputField input;

    private readonly List<string> inputHistory = new() { "" };
    private int currentInputHistoryIndex = 0;

    void Start() {
        input.onSubmit.AddListener(_ => OnSubmit());
    }

    void Update() {
        OnKeydown();
    }

    private void OnSubmit() {
        if (!input.isFocused) return;

        string text = input.text;

        AddToHistory(text);

        TerminalEvent.AddToStream($"<color=#00FF00>user@host</color>:<color=#1E90FF>directory</color>$ {text}");
        TerminalEvent.ExecuteCommand(text);

        Clear();
    }

    private void OnKeydown() {
        if (!input.isFocused) return;

        Keyboard keyboard = Keyboard.current;

        if (keyboard.upArrowKey.wasPressedThisFrame) {
            currentInputHistoryIndex = Mathf.Max(currentInputHistoryIndex - 1, 0);
            SetInputFromHistory();
        }

        if (keyboard.downArrowKey.wasPressedThisFrame) {
            currentInputHistoryIndex = Mathf.Min(currentInputHistoryIndex + 1, inputHistory.Count);
            SetInputFromHistory();
        }

        if (keyboard.ctrlKey.isPressed && keyboard.cKey.wasPressedThisFrame) {
            Clear();
        }
    }

    private void AddToHistory(string text) {
        inputHistory.Add(text);
        currentInputHistoryIndex = inputHistory.Count;
    }

    private void SetInputFromHistory() {
        if (currentInputHistoryIndex >= inputHistory.Count) {
            Clear();
        } else {
            input.text = inputHistory[currentInputHistoryIndex];
        }

        input.MoveToEndOfLine(false, false);
    }

    private void Clear() {
        input.text = "";
        input.ActivateInputField();
    }
}
