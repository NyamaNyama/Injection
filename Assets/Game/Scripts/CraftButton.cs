using UnityEngine;

public class CraftButton : MonoBehaviour
{
    public CraftingArea craftingArea;

    public void OnCraftButtonPressed()
    {
        craftingArea.CraftItems();
    }
}
