using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradePool : MonoBehaviour
{
    public List<Upgrade> upgrades;

    public PlayerShooting playerShooting;
    public List<Button> buttons;

    Dictionary<Button, Upgrade> buttonUpgradePairs = new();

    private void Awake()
    {
        foreach (var item in buttons)
        {
            item.onClick.AddListener(() => UnlockBehaviour(item));
        }
    }


    public void AssignBehaviourToButtons()
    {
        buttonUpgradePairs.Clear();
        var templist = new List<Upgrade>(upgrades);
        foreach (var item in buttons)
        {
            if (templist.Count == 0)
            {
                item.GetComponentInChildren<TextMeshProUGUI>().text = "";
                item.interactable = false;

                continue;
            }

            int randomIndex = Random.Range(0, templist.Count);

            var randomUpgrade = templist[randomIndex];

            var behaviour = randomUpgrade.PreviewUpgrade(upgrades);


            buttonUpgradePairs.Add(item, randomUpgrade);
            item.GetComponentInChildren<TextMeshProUGUI>().text = behaviour.name;

            templist.Remove(randomUpgrade);
        }
    }

    void UnlockBehaviour(Button button)
    {
        var upgradeToUnlock = buttonUpgradePairs[button];
        var behaviour = upgradeToUnlock.GetUpgrade(upgrades);
        playerShooting.AddBehaviour(behaviour, behaviour.IsNewUpgrade);

        foreach (var item in buttons)
        {
            item.gameObject.SetActive(false);
        }
        Time.timeScale = 1.0f;
    }

}


[System.Serializable]
public class Upgrade
{
    public List<ShootBehaviourBaseClass> StagesOfUpgrade;

    public List<ShootBehaviourBaseClass> UpgradedBehaviours;

    public ShootBehaviourBaseClass PreviewUpgrade(List<Upgrade> upgrades)
    {
        return StagesOfUpgrade[0];
    }

    public ShootBehaviourBaseClass GetUpgrade(List<Upgrade> upgrades)
    {
        var upgradeToReturn = StagesOfUpgrade[0];

        StagesOfUpgrade.Remove(upgradeToReturn);
        UpgradedBehaviours.Add(upgradeToReturn);

        if (StagesOfUpgrade.Count == 0)
        {
            upgrades.Remove(this);
        }

        return upgradeToReturn;
    }
}