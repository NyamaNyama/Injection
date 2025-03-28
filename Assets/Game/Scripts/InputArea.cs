using UnityEngine;

public class InputArea : MonoBehaviour
{
    [HideInInspector] public ItemObject currentItem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            ItemObject item = other.GetComponent<ItemObject>();
            if (item != null)
            {
                currentItem = item;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            ItemObject item = other.GetComponent<ItemObject>();
            if (item != null && item == currentItem)
            {
                currentItem = null;
            }
        }
    }
}
