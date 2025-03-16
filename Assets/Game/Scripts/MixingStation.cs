using System.Collections.Generic;
using UnityEngine;

public class MixingStation : MonoBehaviour
{
    [System.Serializable]
    public class MixingRecipe
    {
        public ItemData itemA;
        public ItemData itemB;
        public ItemData result;
    }

    public List<MixingRecipe> mixingRecipes = new List<MixingRecipe>();

    // Метод для смешивания двух предметов
    public ItemData Mix(ItemData item1, ItemData item2)
    {
        foreach (var recipe in mixingRecipes)
        {
            if ((recipe.itemA == item1 && recipe.itemB == item2) || (recipe.itemA == item2 && recipe.itemB == item1))
            {
                return recipe.result;
            }
        }
        return null;
    }
}
