using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Close : MonoBehaviour {
    public Window window;

    public void CloseWindow() {
        WindowEvent.CloseWindow(window);
    }
}
