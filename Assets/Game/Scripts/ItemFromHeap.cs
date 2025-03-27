using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Scripts
{
    public class ItemFromHeap : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ItemObject spawnObject;
        private Vector2 _spawnPos;

        private void Start()
        {
            Collider2D collider= GetComponent<Collider2D>();
            _spawnPos = new Vector2(collider.bounds.min.x, collider.bounds.max.y / 2);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Instantiate(spawnObject, _spawnPos, Quaternion.identity);
        }
    }
} 