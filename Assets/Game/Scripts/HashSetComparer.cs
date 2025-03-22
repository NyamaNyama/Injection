using System.Collections.Generic;

public class HashSetComparer : IEqualityComparer<HashSet<ItemData>>
{
    public static readonly HashSetComparer Instance = new HashSetComparer();

    public bool Equals(HashSet<ItemData> x, HashSet<ItemData> y)
    {
        return x.SetEquals(y);
    }

    public int GetHashCode(HashSet<ItemData> obj)
    {
        int hash = 0;
        foreach (var item in obj)
        {
            hash ^= item.GetHashCode();
        }
        return hash;
    }
}
