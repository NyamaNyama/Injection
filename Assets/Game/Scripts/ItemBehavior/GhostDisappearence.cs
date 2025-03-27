using System;
using UnityEngine;

public class GhostDisappearence : MonoBehaviour
{
    [SerializeField] private float ghostLifeTime;
    private SpriteRenderer _sprite;
    private float _timeLeft;
    

    private void Start()
    {
        _timeLeft = ghostLifeTime;
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Color spritecolor = _sprite.color;
        spritecolor.a =  Mathf.Clamp(_timeLeft / ghostLifeTime, 0, 1);
        _sprite.color = spritecolor;
        if (_sprite.color.a == 0)
        {
            Destroy(gameObject);
        }
        _timeLeft -= Time.deltaTime;
    }
}
