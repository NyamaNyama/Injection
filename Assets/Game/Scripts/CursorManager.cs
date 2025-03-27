using System;
using UnityEngine;

namespace Game.Scripts
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] private Texture2D defaultCursor;
        [SerializeField] private Texture2D clickCursor;
        [SerializeField] private Texture2D dragCursor;
        private Vector2 _hotspot;

        public static CursorManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Cursor.SetCursor(defaultCursor,_hotspot,CursorMode.Auto);
            _hotspot = new Vector2(defaultCursor.width / 2, defaultCursor.height / 2);
        }

        public void SetInterationCursor(bool isInteracting)
        {
            if (isInteracting)
            {
                Cursor.SetCursor(clickCursor,_hotspot,CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(defaultCursor,_hotspot,CursorMode.Auto);
            }
        }
        
        public void SetDragCursor(bool isInteracting)
        {
            if (isInteracting)
            {
                Cursor.SetCursor(dragCursor,_hotspot,CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(defaultCursor,_hotspot,CursorMode.Auto);
            }
        }
    }
}