using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Dash")]
public class Dash : Ability
{
    public int boost;
    private int initial_speed;

    public override void Cast(GameObject target)
    {
        initial_speed = target.GetComponent<Player>().getSpeed();
        target.GetComponent<Player>().setSpeed(boost + initial_speed);
    }

    public override void Reverse(GameObject target)
    {
        target.GetComponent<Player>().setSpeed(initial_speed);
    }
}
