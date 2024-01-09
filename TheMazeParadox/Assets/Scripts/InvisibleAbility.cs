using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class InvisibleAbility : Ability
{
    public static bool bought = false;

    public override void Activate(GameObject parent)
    {
        // check if the ability has been bought first
        if (bought) {
            // change player tag to avoid being spotted
            parent.transform.gameObject.tag = "Invisible";
            // play particles
            ParticleSystem _particleSystem = parent.transform.GetComponentInChildren<ParticleSystem>();
            _particleSystem.Play();
        }
    }

    public override void Deactivate(GameObject parent)
    {
        // restore player tag
        parent.transform.gameObject.tag = "Player";
        // stop particles
        ParticleSystem _particleSystem = parent.transform.GetComponentInChildren<ParticleSystem>();
        _particleSystem.Stop();
        bought = false;
    }
}
