using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    // variables
    public new string name;
    public float cooldownTime;
    public float activeTime;

    // method to activate an ability
    public virtual void Activate(GameObject parent)
    {

    }

    // method to deactive an ability
    public virtual void Deactivate(GameObject parent)
    {

    }
}
