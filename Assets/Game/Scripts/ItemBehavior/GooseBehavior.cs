using System;
using UnityEngine;

namespace Game.Scripts.ItemBehavior
{
    public class GooseBehavior : MonoBehaviour
    {
        [SerializeField] private AudioClip gooseSound;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float jumpCooldown;
        [SerializeField] private float circleRange;
        [SerializeField] private LayerMask tableLayer;
        private float _time;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _time = jumpCooldown;
        }

        private void Update()
        {
            if (_time >= jumpCooldown )
            {
                Jump();
                _time = 0;
            }

            _time += Time.deltaTime;
        }

        private void Jump()
        {
            SoundFXManager.instance.PlaySoundFXClip(gooseSound,gameObject.transform,1);
            _rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
        
    }
}