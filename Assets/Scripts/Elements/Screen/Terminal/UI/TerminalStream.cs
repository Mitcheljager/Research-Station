using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TerminalStream : MonoBehaviour {
    public TextMeshProUGUI streamText;

    private string currentText = "";

    void OnEnable() {
        TerminalEvent.OnAddToStream += AddToStream;
    }

    void OnDisable() {
        TerminalEvent.OnAddToStream -= AddToStream;
    }

    void Start() {
        Clear();
    }

    private void AddToCurrentText(string text) {
        currentText += text + "\n";
        streamText.text = currentText;
    }

    public void Clear() {
        streamText.text = "";
        currentText = "";
    }

    private void AddToStream(string text, float delay) {
        if (delay > 0f) StartCoroutine(DelayAddToStream(text, delay));
        else AddToCurrentText(text);
    }

    private IEnumerator DelayAddToStream(string text, float delay) {
        yield return new WaitForSeconds(delay);
        AddToCurrentText(text);
    }
}
