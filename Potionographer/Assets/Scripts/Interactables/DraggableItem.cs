using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string itemName;
    private Vector3 originalPosition;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position;  //keep track of where item was initially
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 screenPos = eventData.position;
        Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 10f));
        //IMPORTANT: Z must be > 0 for ScreenToWorldPoint
        worldPos.z = 0f;

        transform.position = worldPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // If not dropped in cauldron, return to origin
        if (!eventData.pointerEnter || eventData.pointerEnter.tag != "Cauldron")
        {
            transform.position = originalPosition;  //return to initial position
        }
    }
}
