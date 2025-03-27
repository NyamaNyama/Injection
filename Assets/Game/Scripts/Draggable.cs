using UnityEngine;
using System.Collections;
using Game.Scripts;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private float dragStartTime;
    public static bool dragPenaltyActive = false;
    private bool dragDisabled = false;
    public static bool invertedMouse = false;
    private static Draggable currentDraggable;

    private void OnMouseDown()
    {
        if (dragPenaltyActive && dragDisabled)
        {
            return;
        }
        CursorManager.instance.SetDragCursor(true);
        offset = gameObject.transform.position - GetMouseWorldPos();
        isDragging = true;
        dragStartTime = Time.time;
        currentDraggable = this;
    }

    private void OnMouseDrag()
    {
        if (isDragging && !dragDisabled)
        {
            transform.position = GetMouseWorldPos() + offset;
            if (dragPenaltyActive && Time.time - dragStartTime >= 5f)
            {
                StopDragging();
            }
        }
    }

    private void OnMouseUp()
    {
        CursorManager.instance.SetDragCursor(false);
        isDragging = false;
        currentDraggable = null;
    }

    private void StopDragging()
    {
        isDragging = false;
        dragDisabled = true;
        StartCoroutine(EnableDragging());
    }

    private IEnumerator EnableDragging()
    {
        yield return new WaitForSeconds(1f);
        dragDisabled = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;

        if (invertedMouse)
        {
            mousePos.x = Screen.width - mousePos.x;
            mousePos.y = Screen.height - mousePos.y;
        }

        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
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
