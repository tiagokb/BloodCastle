using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{

    private NavMeshAgent agent;

    private AnimationsController animationsController;
    private MovementBehaviour movement;

    private EnemyStats stats;

    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        animationsController = GetComponent<AnimationsController>();
        movement= GetComponent<MovementBehaviour>();

        stats= GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {

        if (agent != null)
        {
            attacking = movement.NpcMoviment(stats.tauntArea, stats.range);
        }
        
        if (attacking)
        {
            animationsController.animateTrigger(AnimatorParams.GOLEM_BASE_LAYER_HIT);
        }

        animationsController.animateFloat(AnimatorParams.GOLEM_BASE_LAYER_WALK, agent.velocity.magnitude);
    }
}
