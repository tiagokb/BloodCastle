using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControll : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject moveGroundAnimation;

    private Stats stats;

    private MovementBehaviour movement;
    private AnimationsController animationsController;

    private NavMeshAgent agent;

    private GameObject target = null;

    private bool attacking = false;

    // Start is called before the first frame update
    private void Start()
    {

        movement = GetComponent<MovementBehaviour>();
        animationsController= GetComponent<AnimationsController>();
        agent = GetComponent<NavMeshAgent>();
        stats= GetComponent<Stats>();
    }
       
    private void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {

            Debug.Log("TODO: roll");
        }

        if (Input.GetMouseButton(1))
        {
            if (stats.life > 0)
            {
                target = movement.PlayerMovement(mainCamera, moveGroundAnimation);
            }
        }

        if (target != null)
        {
            attacking = movement.targeting(target, stats.range);
        }
        
        animationsController.animateFloat(AnimatorParams.BASE_LAYER_MOVING, agent.velocity.magnitude);

        if (target != null && attacking) {
            animationsController.animateBool(AnimatorParams.BASE_LAYER_ATTACKING, true);
        } else
        {
            animationsController.animateBool(AnimatorParams.BASE_LAYER_ATTACKING, false);
        }

        if (stats.life <= 0)
        {
            target = null;
            animationsController.animateBool(AnimatorParams.BASE_LAYER_DIE, true);
        }
    }
}
