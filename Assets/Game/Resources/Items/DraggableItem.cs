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
        rb.bodyType = RigidbodyType2D.Kinematic; // ��������� ������
        parentAfterDrag = transform.parent;
        transform.SetParent(null, true); // ������� �� ��������, �� ��������� �������
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(eventData.position);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // �������� ������ �������
        transform.SetParent(parentAfterDrag, true); // ���������� � ��������
    }
}
