using UnityEngine;
using TMPro;

public class UI_UpgradeCard : MonoBehaviour
{
    public Upgrade upgrade;
    public TextMeshProUGUI NameUI;
    public TextMeshProUGUI DescriptionUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetUpgrade(Upgrade upgrade)
    {
        this.upgrade = upgrade;
        NameUI.text = upgrade.name;
        DescriptionUI.text = upgrade.description;
    }

    public void GetUpgrade()
    {
        upgrade.SetUpgrade();
        EventManager.OnUpgradeSelect();
    }

}
