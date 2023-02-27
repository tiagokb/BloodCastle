using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerCombat : Combat
{ 
    protected override void Targeting()
    {
        if (targetedEnemy != null)
        {

            if (targetedEnemy.GetComponent<Combat>() != null && 
                targetedEnemy.GetComponent<ITargetable>() != null && targetedEnemy.GetComponent<ITargetable>().IsKillable)
            {
                if (targetedEnemy.GetComponent<Stats>() == null || !targetedEnemy.GetComponent<Combat>().IsAlive())
                {

                    targetedEnemy = null;
                    animator.SetBool(AnimatorParams.ATTACKING, false);
                }
                else if (isInvulnerable)
                {

                    animator.SetBool(AnimatorParams.ATTACKING, false);
                }
                else
                {

                    animator.SetBool(AnimatorParams.ATTACKING, movementBehaviour.targeting(targetedEnemy, stats.GetStatValue(StatsNames.Range)));
                }
            }
        }
        else if (animator.GetBool(AnimatorParams.ATTACKING))
        {

            animator.SetBool(AnimatorParams.ATTACKING, false);
        }
    }

    protected override void Die()
    {
        movementBehaviour.Stop();
        TargetedEnemy = null;
        animator.SetBool(AnimatorParams.DIE, true);
        isNotDead = false;
        base.Die();
    }
}
