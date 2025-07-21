using UnityEngine;
using UnityEngine.Events;
public static class EventManager {

    // Player Events -------------------------------------------------------
    
    public static event UnityAction PlayerDeath;
    public static void OnPlayerDeath() { PlayerDeath?.Invoke(); }

    public static event UnityAction<int> PlayerDamaged;
    public static void OnPlayerDamaged(int currentHealth) { PlayerDamaged?.Invoke(currentHealth); }

    public static event UnityAction<int> PlayerGainedExp;
    public static void OnPlayerGainExp(int currentExp) { PlayerGainedExp?.Invoke(currentExp); }
    
    public static event UnityAction PlayerUpgraded;
    public static void OnPlayerUpgrade() { PlayerUpgraded?.Invoke(); }

    // UI Events ---------------------------------------------------------

    public static event UnityAction UpgradeSelected;
    public static void OnUpgradeSelect() { UpgradeSelected?.Invoke(); }
}
