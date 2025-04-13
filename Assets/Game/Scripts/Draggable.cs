using System;
using UnityEngine;
using System.Collections;
using Game.Scripts;
using UnityEngine.Serialization;

public class Draggable : MonoBehaviour
{
    
    public bool isDragging { get; private set; }
    private float dragStartTime;
    public static bool dragPenaltyActive = false;
    private bool dragDisabled = false;
    public static bool invertedMouse = false;
    private static Draggable currentDraggable;
    
    private Camera _mainCam;
    [SerializeField] private LayerMask tableLayer;
    private Rigidbody2D _rb;
    
    private TargetJoint2D _targetJoint;
    [SerializeField][Range(0.1f, 50f)] private float frequency = 8f;
    [SerializeField][Range(0f, 1f)] private float damping = 1f;
    [SerializeField] private float jointMaxForce = 1000f;

    [SerializeField] private float maxCursorDistance;
    private float _colliderCheckRadius;

    
    private void Awake()
    {
        _mainCam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
        Collider2D collider = GetComponent<Collider2D>();
        _colliderCheckRadius = Vector2.Distance(collider.bounds.max, collider.bounds.min) / 2;
    }
    

    private void OnMouseDown()
    {
        if (dragPenaltyActive && dragDisabled)
        {
            return;
        }
        StartDragging();
    }

    private void OnMouseDrag()
    {
        if (!isDragging || _targetJoint == null) return;
        _targetJoint.target = GetMouseWorldPos();
        if (Vector2.Distance(transform.position, GetMouseWorldPos()) >= maxCursorDistance)
        {
            if (Physics2D.OverlapCircle(GetMouseWorldPos(), _colliderCheckRadius, tableLayer))
            {
                _rb.MovePosition(GetMouseWorldPos());
            }
        }
        
        WeakHands();
    }
    
    
    private void OnMouseUp()
    {
        StopDragging();
    }

    private void StartDragging()
    {
        _rb.mass = 0.01f;
        _rb.gravityScale = 0;
        _rb.linearVelocity = Vector2.zero;
        
        _targetJoint = gameObject.AddComponent<TargetJoint2D>();
        _targetJoint.autoConfigureTarget = false;
        _targetJoint.dampingRatio = damping;
        _targetJoint.frequency = frequency;
        _targetJoint.target = GetMouseWorldPos();
        _targetJoint.maxForce = jointMaxForce;
        
        CursorManager.instance.SetDragCursor(true);
        isDragging = true;
        dragStartTime = Time.time;
    }

    public void StopDragging()
    {
        if (_targetJoint != null)
        {
            Destroy(_targetJoint);
            _targetJoint = null;
        }

        _rb.mass = 1;
        _rb.gravityScale = 1;
        _rb.linearVelocity = Vector2.zero;
        _rb.angularVelocity = 0f;
        
        isDragging = false;
        CursorManager.instance.SetDragCursor(false);
    }
    
    private Vector2 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        print(_mainCam.ScreenToWorldPoint(mousePos));
        return _mainCam.ScreenToWorldPoint(mousePos);
    }
    
    public static void ForceRelease()
    {
        if (currentDraggable != null)
        {
            currentDraggable.isDragging = false;
            currentDraggable = null;
        }
    }
    
        
    private void WeakHands()
    {
        if ((dragPenaltyActive && Time.time - dragStartTime >= 5f))
        {
            StopDragging();
        }
    }
}
