using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Combat
{

    private NavMeshAgent agent;
    private float tauntArea;
    private float range;
    private float expOnDie;

    // Start is called before the first frame update
    protected override void Init()
    { 

        agent = GetComponent<NavMeshAgent>();
        tauntArea = stats.GetStatValue(StatsNames.TauntArea);
        range = stats.GetStatValue(StatsNames.Range);
        expOnDie = stats.GetStatValue(StatsNames.ExpOnDie);
    }

    protected override void Targeting()
    {
        if (IsAlive())
        {
            if (agent != null)
            {

                if (movementBehaviour.NpcMoviment(tauntArea, range))
                {
                    AttackAction();
                }
            }

            animator.SetFloat(AnimatorParams.MOVING, agent.velocity.magnitude);
        }
    }

    protected override void Die()
    {
        movementBehaviour.Stop();
        Destroy(GetComponent<Targetable>());
        animator.SetTrigger(AnimatorParams.DIE);
        isNotDead = false;
        base.Die();
    }

    public void AttackAction()
    {
        animator.SetTrigger(AnimatorParams.ATTACKING);
    }

    public void StrongAttack()
    {
        Debug.Log("Strong Attack");
    }

    public override void TakeDamage(float damage, GameObject striker)
    {

        stats.TakeDamage(damage);

        if (!IsAlive())
        {
            LevelUpStats levelUpStats = striker.GetComponent<LevelUpStats>();

            if (levelUpStats != null)
            {
                levelUpStats.SetExperience(expOnDie);
            }
        }
    }
}
