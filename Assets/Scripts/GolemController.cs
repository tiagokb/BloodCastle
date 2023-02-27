using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemController : MonoBehaviour
{

    public Stats stats;

    Animator anim;
    NavMeshAgent mNavMeshAgent;
    float atkTimer;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        /*anim = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        mNavMeshAgent.updateRotation = false;
        atkTimer = stats.getAtkSpeed();*/
    }

    // Update is called once per frame
    void Update()
    {
        //Tracking();
    }

    private void Tracking()
    {

        if (player.GetComponent<Animator>().GetBool(AnimatorParams.DIE))
        {
            anim.SetTrigger(AnimatorParams.RAGE);
            return;
        }
    }

    private void resetAtkTimer()
    {
        atkTimer = 2f;
    }

    private void resetPath()
    {
        /*ResetTriggerDamage();
        mNavMeshAgent.ResetPath();*/
    }

    

    private void TriggerDamage()
    {
        anim.SetTrigger(AnimatorParams.ATTACKING);
    }

    private void ResetTriggerDamage()
    {
        anim.ResetTrigger(AnimatorParams.ATTACKING);
    }

    private void moveTo(Vector3 desiredPosition, float stoppingDistance)
    {
        resetPath();
        mNavMeshAgent.stoppingDistance = stoppingDistance;
        mNavMeshAgent.SetDestination(desiredPosition);
        transform.LookAt(desiredPosition);
    }

    public void Hit()
    {
        player.GetComponent<Combat>().TakeDamage(stats.GetStatValue(StatsNames.Strength));
    }
}
