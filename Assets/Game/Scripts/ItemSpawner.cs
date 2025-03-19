using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // Префаб предмета
    public Transform spawnPoint;  // Точка появления

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
