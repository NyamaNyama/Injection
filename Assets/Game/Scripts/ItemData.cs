using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Lab/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    [TextArea] public string description;
}