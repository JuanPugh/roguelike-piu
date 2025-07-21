using UnityEngine;

public class UI_ExpBar : UI_Bar
{
    public override void Start()
    {
        base.Start();
        UpdateMaxValue();
        EventManager.PlayerGainedExp += updateBar;
        EventManager.PlayerUpgraded += UpdateMaxValue;
    }

    public override void UpdateMaxValue()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        max_value = player.getMaxExp();
    }
}
