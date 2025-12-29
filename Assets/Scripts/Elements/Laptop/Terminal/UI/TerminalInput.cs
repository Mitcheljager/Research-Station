using TMPro;
using UnityEngine;

public class TerminalInput : MonoBehaviour {
    public TMP_InputField input;

    void Start() {
        input.onSubmit.AddListener(e => {
            if (!input.isFocused) return;

            string text = input.text;

            TerminalEvents.ExecuteCommand(text);

            input.text = "";
            input.ActivateInputField();
        });
    }
}
