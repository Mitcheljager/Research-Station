using System.Collections.Generic;
using UnityEngine;

public class WindowTray : MonoBehaviour {
    public Screen screen;
    public GameObject windowTrayItemPrefab;

    void OnEnable() {
        WindowEvent.OnUpdateWindow += UpdateItems;
    }

    void OnDisable() {
        WindowEvent.OnUpdateWindow -= UpdateItems;
    }

    void Start() {
        UpdateItems(null);
    }

    public void UpdateItems(Window updatedWindow) {
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }

        foreach(Window window in screen.activeWindows) {
            GameObject instantiatedGameObject = Instantiate(windowTrayItemPrefab, transform);

            WindowTrayItem windowTrayItem = instantiatedGameObject.GetComponent<WindowTrayItem>();

            windowTrayItem.window = window;
            windowTrayItem.minimize.window = window;
            windowTrayItem.SetMinimized();
        }
    }
}
