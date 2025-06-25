using System;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public float cooldownTime;
    public float activeTime;

    public abstract void Cast(GameObject target);
    public abstract void Reverse(GameObject target);
}
