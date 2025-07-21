using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    float cooldownTime;
    float activeTime;

    private enum AbilityState
    {
        Ready,
        Active,
        Cooldown
    }

    public Ability ability;
    private AbilityState state;

    // Update is called once per frame
    void Update()
    {

        
        switch (state)
        {
            case AbilityState.Ready:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ability.Cast(gameObject);
                    state = AbilityState.Active;
                    activeTime = ability.activeTime;
                }
                break;

            case AbilityState.Active:
                if (activeTime > 0) { activeTime -= Time.deltaTime; }
                else
                {
                    ability.Reverse(gameObject);
                   state = AbilityState.Cooldown;
                    cooldownTime = ability.cooldownTime;
                }
                break;
                
            case AbilityState.Cooldown:
                if(cooldownTime > 0) { cooldownTime -= Time.deltaTime; } 
                else { state = AbilityState.Ready; }
                break;
        }

        
    }
}
