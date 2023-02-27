using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesHolder : MonoBehaviour
{

    [Header("Ability 5")]
    public Ability ability5;
    public AbilityState ability5State = AbilityState.ready;
    public float cooldownTime5;
    public float activeTime5;
    [SerializeReference]
    KeyCode ability5KeyCode;

    // Update is called once per frame
    void Update()
    {

        Ability5();
    }

    void Ability5()
    {

        switch (ability5State)
        {
            case AbilityState.ready:

                if (Input.GetKeyDown(ability5KeyCode))
                {
                    ability5.OnActive(gameObject);
                    ability5State = AbilityState.active;
                    activeTime5 = ability5.activeTime;
                }
                break;
            case AbilityState.active:

                if (activeTime5 > 0)
                {

                    activeTime5 -= Time.deltaTime;
                }
                else
                {
                    ability5.OnCooldown(gameObject);
                    ability5State = AbilityState.cooldown;
                    cooldownTime5 = ability5.cooldownTime;
                }
                break;
            case AbilityState.cooldown:

                if (cooldownTime5 > 0)
                {

                    cooldownTime5 -= Time.deltaTime;
                }
                else
                {
                    ability5.OnReady(gameObject);
                    ability5State = AbilityState.ready;
                }
                break;
        }
    }
}
