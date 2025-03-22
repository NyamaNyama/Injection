using System.Collections.Generic;
using UnityEngine;

public class CraftingArea : MonoBehaviour
{
    public MixingStation mixingStation; 
    public ItemSpawner itemSpawner; 
    public GameObject craftButton;

    private List<ItemObject> itemsInArea = new List<ItemObject>();  
    private bool isCraftingInProgress = false; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item")) 
        {
            ItemObject itemObject = other.GetComponent<ItemObject>();
            if (itemObject != null)
            {
                itemsInArea.Add(itemObject); 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            ItemObject itemObject = other.GetComponent<ItemObject>();
            if (itemObject != null)
            {
                itemsInArea.Remove(itemObject); 
            }
        }
    }

    public void CraftItems()
    {
        if (isCraftingInProgress)
            return;

        if (itemsInArea.Count != 2)
        {
            Debug.Log("Нужно два предмета для крафта!");
            return;
        }

        isCraftingInProgress = true;

        ItemObject item1 = itemsInArea[0];
        ItemObject item2 = itemsInArea[1];

        ItemData result = mixingStation.Mix(item1.GetItemData(), item2.GetItemData()); 

        if (result != null)
        {
            Destroy(item1.gameObject);
            Destroy(item2.gameObject);

            itemSpawner.SpawnItem(result);

            itemsInArea.Clear();
        }
        else
        {
            Debug.Log("Рецепт не найден для этих предметов.");
        }

        isCraftingInProgress = false;
    }
}
