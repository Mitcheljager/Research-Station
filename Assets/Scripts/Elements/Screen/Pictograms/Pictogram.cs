using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pictogram : MonoBehaviour {
    public Image iconImage;
    public TMP_Text nameText;

    [Fade] public GameObject relatedWindowPrefab;

    private Screen screen;

    void Start() {
        screen = GetComponentInParent<Screen>();

        Initialize();
    }

    public void Initialize() {
        Window window = relatedWindowPrefab.GetComponent<Window>();

        iconImage.sprite = window.iconSprite;
        nameText.text = window.windowName;
    }

    public void OpenOrCreateWindow() {
        WindowEvent.CreateWindow(relatedWindowPrefab);
    }
}
