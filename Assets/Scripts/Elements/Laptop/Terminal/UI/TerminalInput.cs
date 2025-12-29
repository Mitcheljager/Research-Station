using TMPro;
using UnityEngine;

public class TerminalInput : MonoBehaviour {
    public TMP_InputField input;

    void Start() {
        input.onSubmit.AddListener(e => {
            if (!input.isFocused) return;

            string text = input.text;

            TerminalEvent.AddToStream($"<color=#00FF00>user@host</color>:<color=#1E90FF>directory</color>$ {text}");
            TerminalEvent.ExecuteCommand(text);

            input.text = "";
            input.ActivateInputField();
        });
    }
}
