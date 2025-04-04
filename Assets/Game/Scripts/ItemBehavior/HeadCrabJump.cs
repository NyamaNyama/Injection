using System;
using UnityEngine;
using Random = System.Random;

namespace Game.Scripts.ItemBehavior
{
    public class HeadCrabJump : MonoBehaviour
    {
        [SerializeField] private float jumpCooldown;
        [SerializeField] private float maxJumpHeight;
        [SerializeField] private float maxJumpLength;
        [SerializeField] private AudioClip headCrabAudio;
        private Rigidbody2D _rb;
        private float _time;
        private SpriteRenderer _sprite;
        private Draggable _drag;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _time = jumpCooldown;
            _rb = GetComponent<Rigidbody2D>();
            _drag = GetComponent<Draggable>();
        }

        private void Update()
        {
            if (_time >= jumpCooldown)
            {
                if (_drag.isDragging)
                {
                    _drag.StopDragging();
                }
                Jump();
                _time -= _time;
            }

            _time += Time.deltaTime;
        }

        private void Jump()
        {
            float coordX = UnityEngine.Random.Range(-maxJumpLength, maxJumpLength);
            float coordY = UnityEngine.Random.Range(0, maxJumpHeight);
            
            if (coordX > 0)
            {
                _sprite.flipX = true;
            }
            else
            {
                _sprite.flipX = false;
            }
            
            SoundFXManager.instance.PlaySoundFXClip(headCrabAudio,transform,0.5f);
            _rb.AddForce(new Vector2(coordX,coordY),ForceMode2D.Impulse);
        }
    }
}