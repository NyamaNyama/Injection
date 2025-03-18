using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Rigidbody2D rb;
    private Transform parentAfterDrag;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rb.bodyType = RigidbodyType2D.Kinematic; // Отключаем физику
        parentAfterDrag = transform.parent;
        transform.SetParent(null, true); // Убираем из родителя, но сохраняем позицию
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(eventData.position);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // Включаем физику обратно
        transform.SetParent(parentAfterDrag, true); // Возвращаем в родителя
    }
}
