using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour {
    public Canvas canvas;

    public List<Window> activeWindows = new();

    void Start() {
        foreach(Window window in canvas.transform.GetComponentsInChildren<Window>()) {
            activeWindows.Add(window);
        }
    }
}
