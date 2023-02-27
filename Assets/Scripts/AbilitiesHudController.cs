using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesHudController : MonoBehaviour
{

    AbilitiesHolder holder;

    [Header("Ability 5")]
    public Image abilityImage5;
    public Image abilityCooldownImage5;

    // Start is called before the first frame update
    void Start()
    {

        holder = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilitiesHolder>();
        abilityImage5.overrideSprite = holder.ability5.icon;
    }

    // Update is called once per frame
    void Update()
    {
        SetupAbility(holder.ability5State, abilityCooldownImage5, holder.ability5.cooldownTime, holder.cooldownTime5);
    }

    void SetupAbility(AbilityState state, Image abilityCooldownHud, float cooldownTime, float actualCooldownTime)
    {

        switch (state)
        {
            case AbilityState.ready:

                if (abilityCooldownHud.fillAmount != 0)
                {
                    abilityCooldownHud.fillAmount = 0;
                }

                break;

            case AbilityState.active:
                abilityCooldownHud.fillAmount = 1;
                break;

            case AbilityState.cooldown:

                if (actualCooldownTime > 0)
                {
                    abilityCooldownHud.fillAmount -= 1 / cooldownTime * Time.deltaTime; 
                }

                break;
        }
    }
}
