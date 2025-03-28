using System.Collections.Generic;
using UnityEngine;

public class MixingStation : MonoBehaviour
{
    [System.Serializable]
    public class CraftingRecipe
    {
        public ItemData itemA;
        public ItemData itemB;
        public ItemObject result;
    }
    private Dictionary<HashSet<ItemData>, ItemObject> mixingRecipes = new Dictionary<HashSet<ItemData>, ItemObject>(HashSetComparer.Instance);
    
    public List<CraftingRecipe> recipesList = new List<CraftingRecipe>();
    private void Awake()
    {
        foreach (var recipe in recipesList)
        {
            var key = new HashSet<ItemData> { recipe.itemA, recipe.itemB };
            if (!mixingRecipes.ContainsKey(key))
            {
                mixingRecipes.Add(key, recipe.result);
            }
        }
    }

    public ItemObject GetRecipeResult(ItemData item1, ItemData item2)
    {
        var key = new HashSet<ItemData> { item1, item2 };
        return mixingRecipes.TryGetValue(key, out var result) ? result : null;
    }
}
