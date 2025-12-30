using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TerminalInput : MonoBehaviour {
    public TMP_InputField input;
    public Window window;

    private readonly List<string> inputHistory = new() { "" };
    private int currentInputHistoryIndex = 0;
    private int previousCaretPosition = 0;
    private bool wasPreviousInputNavigation = false;

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

        bool any = keyboard.anyKey.wasPressedThisFrame;
        bool up = keyboard.upArrowKey.wasPressedThisFrame;
        bool down = keyboard.downArrowKey.wasPressedThisFrame;

        if (!any) return;

        if (up && (previousCaretPosition == 0 || wasPreviousInputNavigation || input.text.Length == 0)) {
            currentInputHistoryIndex = Mathf.Max(currentInputHistoryIndex - 1, 0);
            SetInputFromHistory();
        }

        if (down && (previousCaretPosition == input.text.Length)) {
            currentInputHistoryIndex = Mathf.Min(currentInputHistoryIndex + 1, inputHistory.Count);
            SetInputFromHistory();
        }

        if (keyboard.ctrlKey.isPressed && keyboard.cKey.wasPressedThisFrame) {
            Clear();
        }

        wasPreviousInputNavigation = any && (up || down);
        previousCaretPosition = input.caretPosition;

        ScrollWindowToBottom();
    }

    private void AddToHistory(string text) {
        if (text.Trim().Length > 0) inputHistory.Add(text);

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

    private void ScrollWindowToBottom() {
        if (window == null) return;
        if (window.scrollRect == null) return;

        window.scrollRect.verticalNormalizedPosition = 0f;
        window.scrollRect.horizontalNormalizedPosition = 0f;
    }
}
