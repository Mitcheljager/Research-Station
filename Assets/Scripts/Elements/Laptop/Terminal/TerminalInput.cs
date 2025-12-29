using TMPro;
using UnityEngine;

public class TerminalInput : MonoBehaviour {
    public TMP_InputField input;
    public Terminal terminal;

    void Start() {
        input.onSubmit.AddListener(e => {
            if (!input.isFocused) return;

            string text = input.text;

            terminal.Run(text);

            input.text = "";
            input.ActivateInputField();
        });
    }
}
