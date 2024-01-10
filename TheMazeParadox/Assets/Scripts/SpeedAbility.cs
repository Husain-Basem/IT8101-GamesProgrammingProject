using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;

[CreateAssetMenu]
public class SpeedAbility : Ability
{
    public static bool bought = false;
    public override void Activate(GameObject parent)
    {
        // check if the ability has been bought first
        if (bought) {
            // play particles
            ParticleSystem _particleSystem = parent.transform.GetComponentInChildren<ParticleSystem>();
            _particleSystem.Play();
            // increase speed
            float _speed = parent.transform.GetComponentInChildren<ThirdPersonMovement>().speed;
            parent.transform.GetComponentInChildren<ThirdPersonMovement>().speed = _speed + 10;
            // play audio
            FindObjectOfType<AudioManager>().Play("Ability");
            
        }
    }

    public override void Deactivate(GameObject parent)
    {
        // stop particles
        ParticleSystem _particleSystem = parent.transform.GetComponentInChildren<ParticleSystem>();
        _particleSystem.Stop();
        // return speed to original state
        parent.transform.GetComponentInChildren<ThirdPersonMovement>().speed = 14;
        // play audio
        if(bought)
        {
            FindObjectOfType<AudioManager>().Play("Ability");
        }
        bought = false;
    }
}
