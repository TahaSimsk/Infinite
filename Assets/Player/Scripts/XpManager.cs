using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpManager : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;
    [SerializeField] UpgradePool pool;
    [SerializeField] int maxLvl;
    [SerializeField] Slider slider;
    [SerializeField] AnimationCurve xpCurve;
    [SerializeField] TextMeshProUGUI levelText;

    float currentXP = 0;
    int currentLvl = 1;

    float currentLvlXPReq = 1;

    void Awake()
    {
        UpdateUI();
    }

    public void GainXp()
    {
        currentLvlXPReq = xpCurve.Evaluate(currentLvl);
        currentXP += 1;
        if (currentXP >= currentLvlXPReq)
        {
            HandleLevelUp();
        }
        UpdateUI();
    }

    void HandleLevelUp()
    {
        currentLvl++;
        currentXP -= currentLvlXPReq;

        foreach (var item in buttons)
        {
            item.gameObject.SetActive(true);
        }

        pool.AssignBehaviourToButtons();

        ChangeTimeScale(0);

    }

    void UpdateUI()
    {
        slider.value = currentXP / currentLvlXPReq;
        levelText.text = $"Level {currentLvl}/{maxLvl}";
    }

    public void ChangeTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
