using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Pictogram : MonoBehaviour {
    public Image iconImage;
    public TMP_Text nameText;

    [Fade] public GameObject relatedWindowPrefab;

    private Screen screen;
    private Window window;

    void Start() {
        screen = GetComponentInParent<Screen>();
        window = relatedWindowPrefab.GetComponent<Window>();

        Initialize();
    }

    private void Initialize() {
        iconImage.sprite = window.iconSprite;
        nameText.text = window.windowName;
    }

    public void OpenOrCreateWindow() {
        Window existingWindow = screen.activeWindows.FirstOrDefault(w => w.windowName == window.windowName);

        if (existingWindow == null || window.allowMultiple) {
            WindowEvent.CreateWindow(relatedWindowPrefab);
        } else {
            WindowEvent.FocusWindow(existingWindow);
        }
    }
}
