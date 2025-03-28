using System;
using Game.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject description;
    public void OnPointerEnter(PointerEventData eventData)
    {
        description.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        description.SetActive(false);
    }

    private ItemData itemData;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItemData(ItemData newItemData)
    {
        itemData = newItemData;

        if (spriteRenderer != null && itemData != null)
        {
            spriteRenderer.sprite = itemData.sprite;
        }
    }

    public ItemData GetItemData()
    {
        return itemData;
    }

    private void OnDestroy()
    {
        ItemFromHeap.activeItems.Remove(this);
    }
}
