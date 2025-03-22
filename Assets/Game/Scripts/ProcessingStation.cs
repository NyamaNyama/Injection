using System.Collections.Generic;
using UnityEngine;

public class ProcessingStation : MonoBehaviour
{
    private Dictionary<ItemData, ItemData> processingRules = new Dictionary<ItemData, ItemData>();

    [System.Serializable]
    public class ProcessingRule
    {
        public ItemData inputItem;
        public ItemData outputItem;
    }

    public List<ProcessingRule> rulesList = new List<ProcessingRule>();

    private void Awake()
    {
        foreach (var rule in rulesList)
        {
            if (!processingRules.ContainsKey(rule.inputItem))
            {
                processingRules.Add(rule.inputItem, rule.outputItem);
            }
        }
    }

    public ItemData Process(ItemData item)
    {
        return processingRules.TryGetValue(item, out var outputItem) ? outputItem : null;
    }
}
