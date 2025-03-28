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
            Debug.LogWarning("ProcessingStation, itemA ��� resultText �� �����������!");
            return;
        }

        ItemData result = processingStation.Process(itemA);
        resultText.text = result != null
            ? "������� �������: " + result.itemName
            : "���� ������� ������ ���������� �����.";
    }

    public void MixItems()
    {
        if (mixingStation == null || itemA == null || itemB == null || resultText == null)
        {
            Debug.LogWarning("MixingStation, itemA, itemB ��� resultText �� �����������!");
            return;
        }

        /*/*ItemData result = mixingStation.Mix(itemA, itemB)#1#;
        resultText.text = result != null
            ? "������ �������: " + result.itemName
            : "������ �� ������.";*/
    }
}
