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

        private void Start()
        {
            _time = jumpCooldown;
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_time >= jumpCooldown)
            {
                Jump();
                _time -= _time;
            }

            _time += Time.deltaTime;
        }

        private void Jump()
        {
            SoundFXManager.instance.PlaySoundFXClip(headCrabAudio,transform,0.5f);
            _rb.AddForce(new Vector2(UnityEngine.Random.Range(-maxJumpLength, maxJumpLength)
                ,UnityEngine.Random.Range(0, maxJumpHeight)),ForceMode2D.Impulse);
        }
    }
}