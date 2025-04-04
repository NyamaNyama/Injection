using System;
using UnityEngine;
using System.Collections;
using Game.Scripts;
using UnityEngine.Serialization;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    public bool isDragging { get; private set; }
    private float dragStartTime;
    public static bool dragPenaltyActive = false;
    private bool dragDisabled = false;
    public static bool invertedMouse = false;
    private static Draggable currentDraggable;
    private Rigidbody2D rb;
    [HideInInspector] public bool wasDrop = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        if (dragPenaltyActive && dragDisabled)
        {
            return;
        }
        rb.bodyType = RigidbodyType2D.Kinematic;
        offset = transform.position - GetMouseWorldPos();
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        
    }

    private void OnMouseDrag()
    {
        CursorManager.instance.SetDragCursor(true);
        isDragging = true;
        dragStartTime = Time.time;
        transform.position = GetMouseWorldPos() + offset;
        WeakHands();
    }

    private void WeakHands()
    {
        if (dragPenaltyActive && Time.time - dragStartTime >= 5f)
        {
            StopDragging();
        }
    }
    
    private void OnMouseUp()
    {
        StopDragging();
    }

    public void StopDragging()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        isDragging = false;
        //dragDisabled = true;
        CursorManager.instance.SetDragCursor(false);
    }

    private IEnumerator EnableDragging()
    {
        yield return new WaitForSeconds(1f);
        dragDisabled = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public static void ForceRelease()
    {
        if (currentDraggable != null)
        {
            currentDraggable.isDragging = false;
            currentDraggable = null;
        }
    }
}
