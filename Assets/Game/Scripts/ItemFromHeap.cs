using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Scripts
{
    public class ItemFromHeap : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] private ItemObject spawnObject;
        private Vector2 _spawnPos;
        public static List<ItemObject> activeItems = new List<ItemObject>();
        private const int MaxItemCount = 10;
        [SerializeField] private Transform spawnPoint;

        private void Start()
        {
            Collider2D collider= GetComponent<Collider2D>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (activeItems.Count < MaxItemCount )
            {
                activeItems.Add(Instantiate(spawnObject, spawnPoint.position, Quaternion.identity));
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            CursorManager.instance.SetInteractionCursor(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CursorManager.instance.SetInteractionCursor(false);
        }
    }
} 