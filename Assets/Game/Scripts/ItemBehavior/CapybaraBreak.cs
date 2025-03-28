using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game.Scripts.ItemBehavior
{
    public class CapybaraBreak : MonoBehaviour
    {
        [SerializeField] private ItemObject capybaraFur;
        [SerializeField] private Draggable capybaraFall;
        private float _currentHeight;
        [SerializeField] private float heightForBreak;
        [SerializeField] private AudioClip breakGlass;

        private bool isFall = false;
        private Rigidbody2D _rb;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_rb.linearVelocityY < 0 && capybaraFall.wasDrop && !isFall)
            {
                capybaraFall.wasDrop = false;
                print("Падает");
                isFall = true;
                _currentHeight = transform.position.y;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (isFall)
            {
                if (_currentHeight - transform.position.y >= heightForBreak)
                {
                    SoundFXManager.instance.PlaySoundFXClip(breakGlass,transform);
                    Instantiate(capybaraFur,transform.position,Quaternion.identity);
                    Destroy(gameObject);
                }
                isFall = false;
            }
            
        }

        private void OnDestroy()
        {
            
        }
    }
}