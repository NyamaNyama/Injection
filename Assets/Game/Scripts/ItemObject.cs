using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
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
}
