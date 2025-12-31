using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Window : MonoBehaviour {
    public Screen screen;
    public Vector2 minSize = new(200, 150);
    public RectTransform rectTransform;
    public ScrollRect scrollRect;
    public Image maximizeImage;
    public Sprite maximizeRestoreSprite;

    public float transitionDurationSeconds = 0.2f;

    [Header("State")]
    public bool isMaximized = false;

    private Sprite maximizeOriginalSprite;
    private Vector2 anchorMinBeforeMaximize;
    private Vector2 anchorMaxBeforeMaximize;
    private Vector2 offsetMinBeforeMaximize;
    private Vector2 offsetMaxBeforeMaximize;

    private Coroutine currentTransition;

    void Start() {
        maximizeOriginalSprite = maximizeImage.sprite;
    }

    public void Maximize() {
        if (currentTransition != null) StopCoroutine(currentTransition);

        if (!isMaximized) {
            anchorMinBeforeMaximize = rectTransform.anchorMin;
            anchorMaxBeforeMaximize = rectTransform.anchorMax;
            offsetMinBeforeMaximize = rectTransform.offsetMin;
            offsetMaxBeforeMaximize = rectTransform.offsetMax;

            currentTransition = StartCoroutine(TransitionToSize(Vector2.zero, Vector2.one, Vector2.zero, Vector2.zero));

            isMaximized = true;
            maximizeImage.sprite = maximizeRestoreSprite;
        } else {
            currentTransition = StartCoroutine(TransitionToSize(anchorMinBeforeMaximize, anchorMaxBeforeMaximize, offsetMinBeforeMaximize, offsetMaxBeforeMaximize));

            isMaximized = false;
            maximizeImage.sprite = maximizeOriginalSprite;
        }
    }

    private IEnumerator TransitionToSize(Vector2 targetAnchorMin, Vector2 targetAnchorMax, Vector2 targetOffsetMin, Vector2 targetOffsetMax) {
        Vector2 startAnchorMin = rectTransform.anchorMin;
        Vector2 startAnchorMax = rectTransform.anchorMax;
        Vector2 startOffsetMin = rectTransform.offsetMin;
        Vector2 startOffsetMax = rectTransform.offsetMax;

        float time = 0f;

        while (time < transitionDurationSeconds) {
            time += Time.deltaTime;
            float currentTime = Mathf.Clamp01(time / transitionDurationSeconds);

            rectTransform.anchorMin = Vector2.Lerp(startAnchorMin, targetAnchorMin, currentTime);
            rectTransform.anchorMax = Vector2.Lerp(startAnchorMax, targetAnchorMax, currentTime);
            rectTransform.offsetMin = Vector2.Lerp(startOffsetMin, targetOffsetMin, currentTime);
            rectTransform.offsetMax = Vector2.Lerp(startOffsetMax, targetOffsetMax, currentTime);

            yield return null;
        }

        rectTransform.anchorMin = targetAnchorMin;
        rectTransform.anchorMax = targetAnchorMax;
        rectTransform.offsetMin = targetOffsetMin;
        rectTransform.offsetMax = targetOffsetMax;

        currentTransition = null;
    }
}
