using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Maximize : MonoBehaviour {
    public Window window;
    public Image maximizeImage;
    public Sprite maximizeRestoreSprite;
    public float transitionDurationSeconds = 0.2f;

    private Sprite maximizeOriginalSprite;
    private Vector2 anchorMinBeforeMaximize;
    private Vector2 anchorMaxBeforeMaximize;
    private Vector2 offsetMinBeforeMaximize;
    private Vector2 offsetMaxBeforeMaximize;

    private Coroutine currentTransition;

    void Start() {
        maximizeOriginalSprite = maximizeImage.sprite;
    }

    public void Toggle() {
        if (currentTransition != null) StopCoroutine(currentTransition);

        if (!window.isMaximized) {
            anchorMinBeforeMaximize = window.rectTransform.anchorMin;
            anchorMaxBeforeMaximize = window.rectTransform.anchorMax;
            offsetMinBeforeMaximize = window.rectTransform.offsetMin;
            offsetMaxBeforeMaximize = window.rectTransform.offsetMax;

            currentTransition = StartCoroutine(TransitionToSize(Vector2.zero, Vector2.one, Vector2.zero, Vector2.zero));

            window.isMaximized = true;
            maximizeImage.sprite = maximizeRestoreSprite;
        } else {
            currentTransition = StartCoroutine(TransitionToSize(anchorMinBeforeMaximize, anchorMaxBeforeMaximize, offsetMinBeforeMaximize, offsetMaxBeforeMaximize));

            window.isMaximized = false;
            maximizeImage.sprite = maximizeOriginalSprite;
        }

        ToggleResizeHandles();
    }

    public void ToggleResizeHandles() {
        foreach(ResizeHandle resizeHandle in window.resizeHandles) {
            resizeHandle.gameObject.SetActive(!window.isMaximized);
        }
    }

    private IEnumerator TransitionToSize(Vector2 targetAnchorMin, Vector2 targetAnchorMax, Vector2 targetOffsetMin, Vector2 targetOffsetMax) {
        Vector2 startAnchorMin = window.rectTransform.anchorMin;
        Vector2 startAnchorMax = window.rectTransform.anchorMax;
        Vector2 startOffsetMin = window.rectTransform.offsetMin;
        Vector2 startOffsetMax = window.rectTransform.offsetMax;

        float time = 0f;

        while (time < transitionDurationSeconds) {
            time += Time.deltaTime;
            float currentTime = Mathf.Clamp01(time / transitionDurationSeconds);

            window.rectTransform.anchorMin = Vector2.Lerp(startAnchorMin, targetAnchorMin, currentTime);
            window.rectTransform.anchorMax = Vector2.Lerp(startAnchorMax, targetAnchorMax, currentTime);
            window.rectTransform.offsetMin = Vector2.Lerp(startOffsetMin, targetOffsetMin, currentTime);
            window.rectTransform.offsetMax = Vector2.Lerp(startOffsetMax, targetOffsetMax, currentTime);

            yield return null;
        }

        window.rectTransform.anchorMin = targetAnchorMin;
        window.rectTransform.anchorMax = targetAnchorMax;
        window.rectTransform.offsetMin = targetOffsetMin;
        window.rectTransform.offsetMax = targetOffsetMax;

        currentTransition = null;
    }
}
