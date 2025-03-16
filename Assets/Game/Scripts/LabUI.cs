using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class LabUI : MonoBehaviour
{
    public ProcessingStation processingStation;
    public MixingStation mixingStation;
    public ItemData itemA, itemB;
    public TextMeshProUGUI resultText; 

    public void ProcessItem()
    {
        if (processingStation == null || itemA == null || resultText == null)
        {
            Debug.LogWarning("ProcessingStation, itemA или resultText не установлены!");
            return;
        }

        ItemData result = processingStation.Process(itemA);
        resultText.text = result != null
            ? "Получен предмет: " + result.itemName
            : "Этот предмет нельзя обработать здесь.";
    }

    public void MixItems()
    {
        if (mixingStation == null || itemA == null || itemB == null || resultText == null)
        {
            Debug.LogWarning("MixingStation, itemA, itemB или resultText не установлены!");
            return;
        }

        ItemData result = mixingStation.Mix(itemA, itemB);
        resultText.text = result != null
            ? "Создан предмет: " + result.itemName
            : "Рецепт не найден.";
    }
}
