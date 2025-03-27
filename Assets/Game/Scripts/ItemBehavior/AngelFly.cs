using System;
using UnityEngine;

public class AngelFly : MonoBehaviour
{
    [SerializeField] private float flySpeed;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityY = flySpeed;
    }
}
