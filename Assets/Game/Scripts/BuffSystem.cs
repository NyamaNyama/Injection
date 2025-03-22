using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class BuffSystem : MonoBehaviour
{
    public TMP_Dropdown buffDropdown;
    public Button applyBuffButton;
    public Volume blurEffect;
    public GameObject pinkGlassesOverlay;

    private Dictionary<string, System.Action> buffs = new Dictionary<string, System.Action>();
    private bool isDragPenaltyActive = false;

    private void Start()
    {
        buffs.Add("Плохое зрение", ApplyBlurEffect);
        buffs.Add("Розовые очки", ApplyPinkGlassesEffect);
        buffs.Add("Слабые руки", ApplyWeakHandsEffect);

        applyBuffButton.onClick.AddListener(ApplySelectedBuff);
    }

    public void ApplySelectedBuff()
    {
        string selectedBuff = buffDropdown.options[buffDropdown.value].text;

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
            Invoke(nameof(DisableBlurEffect), 5f);
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
            pinkGlassesOverlay.SetActive(true);
            Invoke(nameof(DisablePinkGlassesEffect), 5f);
        }
    }

    private void DisablePinkGlassesEffect()
    {
        if (pinkGlassesOverlay != null)
        {
            pinkGlassesOverlay.SetActive(false);
        }
    }

    private void ApplyWeakHandsEffect()
    {
        if (!isDragPenaltyActive)
        {
            isDragPenaltyActive = true;
            StartCoroutine(WeakHandsCoroutine());
        }
    }

    private IEnumerator WeakHandsCoroutine()
    {
        Draggable.dragPenaltyActive = true;
        yield return new WaitForSeconds(30f);
        Draggable.dragPenaltyActive = false;
        isDragPenaltyActive = false;
    }
}