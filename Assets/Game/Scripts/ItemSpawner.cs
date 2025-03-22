using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; 
    public Transform spawnPoint;  

    public void SpawnItem(ItemData itemData)
    {
        GameObject newItem = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
        ItemObject itemObject = newItem.GetComponent<ItemObject>();

        if (itemObject != null)
        {
            itemObject.SetItemData(itemData);
        }
    }
}
