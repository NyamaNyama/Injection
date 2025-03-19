using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;
using System.Collections.Generic;  // Добавлено пространство имен для Dictionary

public class BuffSystem : MonoBehaviour
{
    public TMP_Dropdown buffDropdown; // Список с выбором баффов (используем TMP_Dropdown)
    public Button applyBuffButton; // Кнопка "Применить"
    public Volume blurEffect; // Пост-обработка для размытия
    public GameObject pinkGlassesOverlay; // Объект для эффекта розовых очков

    private Dictionary<string, System.Action> buffs = new Dictionary<string, System.Action>(); // Используем Dictionary

    private void Start()
    {
        // Добавляем все баффы в список
        buffs.Add("Плохое зрение", ApplyBlurEffect);
        buffs.Add("Розовые очки", ApplyPinkGlassesEffect);

        // Подписываем кнопку на событие
        applyBuffButton.onClick.AddListener(ApplySelectedBuff); // Подключаем метод к кнопке
    }

    public void ApplySelectedBuff()  // Изменено на public
    {
        // Получаем выбранный бафф из Dropdown
        string selectedBuff = buffDropdown.options[buffDropdown.value].text;

        // Применяем выбранный бафф
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
            Invoke(nameof(DisableBlurEffect), 5f); // Размытие на 5 секунд
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
            pinkGlassesOverlay.SetActive(true); // Включаем фильтр розовых очков
            Invoke(nameof(DisablePinkGlassesEffect), 5f); // Отключаем эффект через 5 секунд
        }
    }

    private void DisablePinkGlassesEffect()
    {
        if (pinkGlassesOverlay != null)
        {
            pinkGlassesOverlay.SetActive(false); // Отключаем фильтр розовых очков
        }
    }
}