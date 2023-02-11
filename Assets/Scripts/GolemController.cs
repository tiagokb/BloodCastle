using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemController : MonoBehaviour
{

    public EnemyStats stats;

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

        if (player.GetComponent<Animator>().GetBool(AnimatorParams.BASE_LAYER_DIE))
        {
            anim.SetTrigger(AnimatorParams.GOLEM_BASE_LAYER_RAGE);
            return;
        }
    }

    private void resetAtkTimer()
    {
        atkTimer = stats.getAtkSpeed();
    }

    private void resetPath()
    {
        /*ResetTriggerDamage();
        mNavMeshAgent.ResetPath();*/
    }

    

    private void TriggerDamage()
    {
        anim.SetTrigger(AnimatorParams.GOLEM_BASE_LAYER_HIT);
    }

    private void ResetTriggerDamage()
    {
        anim.ResetTrigger(AnimatorParams.GOLEM_BASE_LAYER_HIT);
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
        player.GetComponent<Stats>().life -= stats.attack;
    }
}
