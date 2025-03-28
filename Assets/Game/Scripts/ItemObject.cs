using System;
using Game.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private GameObject description; 

    public bool isLocked = false;
    

    public ItemData GetItemData()
    {
        return itemData;
    }

    public void LockItem()
    {
        isLocked = true;
        Draggable draggable = GetComponent<Draggable>();
        if (draggable != null)
        {
            draggable.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (description != null)
            description.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (description != null)
            description.SetActive(false);
    }
}
