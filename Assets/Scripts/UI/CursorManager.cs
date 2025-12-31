using UnityEngine;
using UnityEngine.InputSystem;

public class CursorManager : MonoBehaviour {
    private Texture2D currentCursor;

    public Transform cursorDownStartedOnTransform;

    public void SetCursor(Texture2D texture, Vector2 hotspot) {
        Cursor.SetCursor(texture, hotspot, CursorMode.Auto);
        currentCursor = texture;
    }

    public void ResetCursor() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        currentCursor = null;
        cursorDownStartedOnTransform = null;
    }

    public void SetCursorDownTransform(Transform targetTransform) {
        cursorDownStartedOnTransform = targetTransform;
    }

    public bool IsCursorDown() {
        return Mouse.current.leftButton.isPressed;
    }

    public bool IsCursorSet() {
        return !!currentCursor;
    }
}
