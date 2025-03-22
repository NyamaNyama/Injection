using System.Collections.Generic;
using UnityEngine;

public class MixingStation : MonoBehaviour
{
    private Dictionary<HashSet<ItemData>, ItemData> mixingRecipes = new Dictionary<HashSet<ItemData>, ItemData>(HashSetComparer.Instance);

    [System.Serializable]
    public class MixingRecipe
    {
        public ItemData itemA;
        public ItemData itemB;
        public ItemData result;
    }

    public List<MixingRecipe> recipesList = new List<MixingRecipe>();

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

    public ItemData Mix(ItemData item1, ItemData item2)
    {
        var key = new HashSet<ItemData> { item1, item2 };
        return mixingRecipes.TryGetValue(key, out var result) ? result : null;
    }
}
