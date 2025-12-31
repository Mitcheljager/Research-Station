using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SetImageColorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Color hoverColor = Color.white;

    private Image image;
    private Color initialColor;

    void Start() {
        image = GetComponent<Image>();
        initialColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        image.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData) {
        image.color = initialColor;
    }
}
