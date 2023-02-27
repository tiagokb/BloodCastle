using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class AbilityRoll : Ability
{

    float dodgeDistance = 3f;

    public override void OnActive(GameObject parent)
    {
        MovementBehaviour movementBehaviour = parent.GetComponent<MovementBehaviour>();
        Combat combat = parent.GetComponent<Combat>();
        Animator animator = combat.GetComponent<Animator>();

        combat.isInvulnerable = true;
        movementBehaviour.DodgeMovement(dodgeDistance);
        animator.SetBool(AnimatorParams.ROLL, true);
    }

    public override void OnCooldown(GameObject parent)
    {
        Combat combat = parent.GetComponent<Combat>();
        Animator animator = combat.GetComponent<Animator>();

        combat.isInvulnerable = false;
        animator.SetBool(AnimatorParams.ROLL, false);
    }
}
