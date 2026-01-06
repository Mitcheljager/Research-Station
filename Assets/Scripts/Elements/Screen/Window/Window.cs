using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour {
    public Vector2 minSize = new(200, 150);
    public RectTransform rectTransform;
    public ScrollRect scrollRect;

    [Header("Fluff")]
    public string windowName;
    public Sprite iconSprite;
    public bool allowMultiple = false;

    [Header("Resize")]
    public ResizeHandle[] resizeHandles;

    [Header("State")]
    [Fade] public Screen screen;
    [Fade] public bool isMaximized = false;
    [Fade] public bool isMinimized = false;
    [Fade] public bool isFocused = false;

    public void AnimateIn(float animationDurationSeconds = 0.1f) {
        StartCoroutine(AnimateInCoroutine(animationDurationSeconds));
    }

    private IEnumerator AnimateInCoroutine(float animationDurationSeconds) {
        rectTransform.localScale = Vector3.zero;

        float time = 0f;

        while (time < animationDurationSeconds) {
            time += Time.deltaTime;

            float step = Mathf.Clamp01(time / animationDurationSeconds);

            rectTransform.localScale = Vector3.LerpUnclamped(Vector3.zero, Vector3.one, step);

            yield return null;
        }

        rectTransform.localScale = Vector3.one;
    }
}
