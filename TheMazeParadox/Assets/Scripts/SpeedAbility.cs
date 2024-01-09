using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class SpeedAbility : Ability
{
    public static bool bought = false;
    private float tempSpeed; // used to restore speed to original value after the ability has ended
    public override void Activate(GameObject parent)
    {
        // check if the ability has been bought first
        if (bought) {
            // play particles
            ParticleSystem _particleSystem = parent.transform.GetComponentInChildren<ParticleSystem>();
            _particleSystem.Play();
            // increase speed
            float _speed = parent.transform.GetComponentInChildren<ThirdPersonMovement>().speed;
            tempSpeed = _speed;
            parent.transform.GetComponentInChildren<ThirdPersonMovement>().speed = _speed + 10;
        }
    }

    public override void Deactivate(GameObject parent)
    {
        // stop particles
        ParticleSystem _particleSystem = parent.transform.GetComponentInChildren<ParticleSystem>();
        _particleSystem.Stop();
        // return speed to original state
        parent.transform.GetComponentInChildren<ThirdPersonMovement>().speed = tempSpeed;
        // reset ability shop
        bought = false;
    }
}
