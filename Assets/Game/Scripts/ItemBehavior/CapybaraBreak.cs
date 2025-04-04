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
        [SerializeField] private LayerMask table;
        
        private Rigidbody2D _rb;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (capybaraFall.isDragging)
            {
                _currentHeight = transform.position.y;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!capybaraFall.isDragging )
            {
                print("Гавнеж");
                if (_currentHeight - transform.position.y >= heightForBreak)
                {
                    SoundFXManager.instance.PlaySoundFXClip(breakGlass,transform);
                    Instantiate(capybaraFur,transform.position,Quaternion.identity);
                    Destroy(gameObject);
                }
            }
            
        }
        
    }
}