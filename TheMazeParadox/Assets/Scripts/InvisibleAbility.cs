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
            // play sound effect
            FindObjectOfType<AudioManager>().Play("Ability");
            // play particles
            ParticleSystem _particleSystem = parent.transform.GetComponentInChildren<ParticleSystem>();
            _particleSystem.Play();
            // reset bought bool to consume the ability
            bought = false;
        }
    }

    public override void Deactivate(GameObject parent)
    {
        // restore player tag
        parent.transform.gameObject.tag = "Player";
        // play sound effect
        FindObjectOfType<AudioManager>().Play("Ability");
        // stop particles
        ParticleSystem _particleSystem = parent.transform.GetComponentInChildren<ParticleSystem>();
        _particleSystem.Stop();
    }
}
