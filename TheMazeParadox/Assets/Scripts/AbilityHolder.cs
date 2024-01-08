using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AbilityHolder : MonoBehaviour
{
    // variables
    public Ability ability;
    float cooldownTime;
    float activeTime;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState state = AbilityState.ready;

    public KeyCode key;

    // Update is called once per frame
    void Update()
    {
        // switch case to set the correct state of the ability
        switch (state)
        {
            // if ability is ready and key is pressed, active ability and set the total active time
            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }
                break;
                // if ability is active, decrease the timer for active until it reaches 0 then put the ability on cooldown
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                } else
                {
                    Debug.Log("Ability deactiviated");
                    ability.Deactivate(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                }
                break;
            // if ability is on cooldown, decrease the timer for cooldown until it reaches 0 then put the ability as ready
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }

        
    }
}
