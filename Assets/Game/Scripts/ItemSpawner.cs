using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; 

    public void SpawnItem(ItemObject item, Vector2 spawnPosition)
    {
        Instantiate(item, spawnPosition, Quaternion.identity);
    }
}
