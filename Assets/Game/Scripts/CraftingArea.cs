using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingArea : MonoBehaviour
{
    public InputArea slot1;
    public InputArea slot2;
    public Transform outputSpawnPoint;
    public MixingStation mixingStation;
    //public ItemSpawner itemSpawner;
    public GameObject craftButton;
    public Animator craftingAnimator;
    public float craftDelay = 1.5f;

    private bool isCraftingInProgress = false;
    public void OnCraftButtonPressed()
    {
        if (isCraftingInProgress)
            return;
        
        if (slot1.currentItem == null || slot2.currentItem == null)
        {
            Debug.Log("Необходимо разместить 2 предмета для крафта!");
            return;
        }

        StartCoroutine(ProcessCraft());
    }

    private IEnumerator ProcessCraft()
    {
        isCraftingInProgress = true;
        
        ItemObject resultPrefab = mixingStation.GetRecipeResult(
            slot1.currentItem.GetItemData(), 
            slot2.currentItem.GetItemData()
        );

        if (resultPrefab != null)
        {
            Destroy(slot1.currentItem.gameObject);
            Destroy(slot2.currentItem.gameObject);
            
            Instantiate(resultPrefab.gameObject, outputSpawnPoint.position, Quaternion.identity);
            
            yield return new WaitForSeconds(craftDelay);
        }
        else
        {
            Debug.Log("Invalid recipe!");
        }

        isCraftingInProgress = false;
    }
}
