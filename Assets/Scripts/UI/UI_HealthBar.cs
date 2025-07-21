using UnityEngine;

public class UI_HealthBar : UI_Bar
{
    public override void Start()
    {
        base.Start();
        UpdateMaxValue();
        EventManager.PlayerDamaged += updateBar;
        EventManager.PlayerUpgraded += UpdateMaxValue;
    }

    public override void UpdateMaxValue()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        max_value = player.getMaxHealth();
    }
}
