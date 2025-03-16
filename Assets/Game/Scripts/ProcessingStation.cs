using System.Collections.Generic;
using UnityEngine;

public class ProcessingStation : MonoBehaviour
{
    [System.Serializable]
    public class ProcessingRule
    {
        public ItemData inputItem;
        public ItemData outputItem;
    }

    public List<ProcessingRule> processingRules = new List<ProcessingRule>();

    // Обрабатывает предмет и возвращает новый
    public ItemData Process(ItemData item)
    {
        foreach (var rule in processingRules)
        {
            if (rule.inputItem == item)
            {
                return rule.outputItem;
            }
        }
        return null;
    }
}
