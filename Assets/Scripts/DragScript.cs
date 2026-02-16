
using UnityEngine;

using UnityEngine.EventSystems;
public class DragScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private RectTransform trans;
    public Canvas canvas;
    SFXScript sfxScript;
    void Start()
    {
        sfxScript = FindFirstObjectByType<SFXScript>();
        trans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public void OnPointerDown(PointerEventData data) {
        Debug.Log("Uzklikskinats uz velkama objekta");
        sfxScript.PlaySFX(0);
    }
    public void OnBeginDrag(PointerEventData data) {
        Debug.Log("Sakta objekta vilksana");
    }
    public void OnDrag(PointerEventData data) {
        Debug.Log("Notiek vilksana");
        Vector2 mousePosition = data.position;
        mousePosition.x = Mathf.Clamp(mousePosition.x,
            0 + trans.rect.width / 2,
            Screen.width - trans.rect.width / 2);

        mousePosition.y = Mathf.Clamp(mousePosition.y,
           0 + trans.rect.width / 2,
           Screen.height - trans.rect.height / 2);

        trans.position = mousePosition;
    }
    public void OnEndDrag(PointerEventData data) {
        Debug.Log("Beigusies objekta vilksana");
    }
}
