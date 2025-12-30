using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SetCursorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {
    public Texture2D cursorTexture;
    public bool keepCursorWhileMouseIsDown = true;

    private CursorManager cursorManager;
    private bool isMouseDown = false;
    private bool isHovering = false;

    void Start() {
        cursorManager = FindFirstObjectByType<CursorManager>();
    }

    void Update() {
        if (!isMouseDown || !keepCursorWhileMouseIsDown) return;
        if (!Mouse.current.leftButton.wasReleasedThisFrame) return;

        isMouseDown = false;

        if (!isHovering) cursorManager.ResetCursor();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        isHovering = true;

        if ((!isMouseDown && keepCursorWhileMouseIsDown) || cursorManager.IsCursorSet()) Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width * 0.5f, cursorTexture.height * 0.5f), CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData) {
        isHovering = false;

        if (!keepCursorWhileMouseIsDown || !isMouseDown) cursorManager.ResetCursor();
    }

    public void OnPointerDown(PointerEventData eventData) {
        isMouseDown = true;
    }
}
