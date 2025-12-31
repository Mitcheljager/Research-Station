using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SetCursorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Texture2D cursorTexture;

    private CursorManager cursorManager;
    private bool isHovering = false;

    void Start() {
        cursorManager = FindFirstObjectByType<CursorManager>();
    }

    void Update() {
        if (!Mouse.current.leftButton.wasReleasedThisFrame) return;
        if (cursorManager.cursorDownStartedOnTransform != transform) return;
        if (isHovering) return;

        cursorManager.ResetCursor();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        isHovering = true;

        if (!cursorManager.IsCursorDown()) Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width * 0.5f, cursorTexture.height * 0.5f), CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData) {
        isHovering = false;

        if (!cursorManager.IsCursorDown()) cursorManager.ResetCursor();
    }
}
