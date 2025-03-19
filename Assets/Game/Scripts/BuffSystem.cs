using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;
using System.Collections.Generic;  // ��������� ������������ ���� ��� Dictionary

public class BuffSystem : MonoBehaviour
{
    public TMP_Dropdown buffDropdown; // ������ � ������� ������ (���������� TMP_Dropdown)
    public Button applyBuffButton; // ������ "���������"
    public Volume blurEffect; // ����-��������� ��� ��������
    public GameObject pinkGlassesOverlay; // ������ ��� ������� ������� �����

    private Dictionary<string, System.Action> buffs = new Dictionary<string, System.Action>(); // ���������� Dictionary

    private void Start()
    {
        // ��������� ��� ����� � ������
        buffs.Add("������ ������", ApplyBlurEffect);
        buffs.Add("������� ����", ApplyPinkGlassesEffect);

        // ����������� ������ �� �������
        applyBuffButton.onClick.AddListener(ApplySelectedBuff); // ���������� ����� � ������
    }

    public void ApplySelectedBuff()  // �������� �� public
    {
        // �������� ��������� ���� �� Dropdown
        string selectedBuff = buffDropdown.options[buffDropdown.value].text;

        // ��������� ��������� ����
        if (buffs.ContainsKey(selectedBuff))
        {
            buffs[selectedBuff].Invoke();
        }
    }

    private void ApplyBlurEffect()
    {
        if (blurEffect != null)
        {
            blurEffect.enabled = true;
            Invoke(nameof(DisableBlurEffect), 5f); // �������� �� 5 ������
        }
    }

    private void DisableBlurEffect()
    {
        if (blurEffect != null)
        {
            blurEffect.enabled = false;
        }
    }

    private void ApplyPinkGlassesEffect()
    {
        if (pinkGlassesOverlay != null)
        {
            pinkGlassesOverlay.SetActive(true); // �������� ������ ������� �����
            Invoke(nameof(DisablePinkGlassesEffect), 5f); // ��������� ������ ����� 5 ������
        }
    }

    private void DisablePinkGlassesEffect()
    {
        if (pinkGlassesOverlay != null)
        {
            pinkGlassesOverlay.SetActive(false); // ��������� ������ ������� �����
        }
    }
}