using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade")]
public class Upgrade : ScriptableObject
{
    public string name;
    public string description;

    public int UpgradeHealth;
    public int UpgradeDamage;
    public int UpgradeSpeed;

    public void SetUpgrade()
    {
        var playerObject = GameObject.FindWithTag("Player");
        if(UpgradeHealth != 0 || UpgradeSpeed != 0)
        {
            Debug.Log("Health: " + UpgradeHealth);
            Player player = playerObject.GetComponent<Player>();
            player.setMaxHealth(player.getMaxHealth() + UpgradeHealth);
            player.setSpeed(player.getSpeed() + UpgradeSpeed);
        }

        if(UpgradeDamage != 0)
        {
            Throw gun = playerObject.GetComponent<Throw>();
            gun.SetDamage(gun.GetDamage() + UpgradeDamage);
        }
    }
}
