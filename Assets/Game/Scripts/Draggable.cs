using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private float dragStartTime;
    public static bool dragPenaltyActive = false;
    private bool dragDisabled = false;

    private void OnMouseDown()
    {
        if (dragPenaltyActive && dragDisabled)
        {
            return;
        }

        offset = gameObject.transform.position - GetMouseWorldPos();
        isDragging = true;
        dragStartTime = Time.time;
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
        isDragging = false;
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
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}