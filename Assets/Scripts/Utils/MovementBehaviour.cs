using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class MovementBehaviour : MonoBehaviour
{

    private NavMeshAgent agent;
    private GameObject player;

    public float rotateSpeedMovement = 0.1f;
    float rotateVelocity;

    private Vector3 originalPosition;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        player = GameObject.FindGameObjectWithTag("Player");
        originalPosition= agent.transform.position;
    }

    internal bool NpcMoviment(float tauntDistance, float stoppingDistance)
    {
        bool attacking = false;

        if (Vector3.Distance(transform.position, player.transform.position) < tauntDistance
            && Vector3.Distance(transform.position, player.transform.position) > stoppingDistance)
        {
            attacking = false;
            moveTo(player.transform.position, 0);
        }
        else if (Vector3.Distance(transform.position, player.transform.position) <= stoppingDistance)
        {

            agent.ResetPath();
            stareAt(player.transform.position);
            attacking = true;
        }
        else
        {

            if (Vector3.Distance(transform.position, originalPosition) > 2)
            {
                moveTo(originalPosition, 0);
            }
            
            attacking = false;
        }

        return attacking;
    }

    #nullable enable
    internal GameObject? PlayerMovement(Camera mainCam, GameObject moveGroundAnimation)
    {

        GameObject? target = null;

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {

                if (Vector3.Distance(hit.point, transform.position) < 0.5f)
                {
                    return target;
                }

                if (hit.collider.gameObject.layer == LayerList.GROUND)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        createClickAnimation(hit, moveGroundAnimation);
                    }

                    if (agent.velocity.magnitude <= 0)
                    {

                        cancelAnimation();
                    }

                    target = null;
                    moveTo(hit.point, 0);
                }

                if (hit.collider.gameObject.layer == LayerList.DESTRUCTIBLE_OBJECT
                    || hit.collider.gameObject.layer == LayerList.ENEMY)
                {

                    target = hit.collider.gameObject;
                }
            }
        }

        return target;
    }

    private void cancelAnimation()
    {
        GetComponent<Animator>().Rebind();
    }

    public bool targeting(GameObject target, float stoppingDistance)
    {

        bool attacking = false;

        if (Vector3.Distance(transform.position, target.transform.position) > stoppingDistance)
        {

            moveTo(target.transform.position, stoppingDistance);
            attacking = false;
        }
        else
        {

            agent.ResetPath();
            transform.LookAt(target.transform.position);
            attacking = true;
        }

        return attacking;
    }

    public void moveTo(Vector3 desiredPosition, float stoppingDistance)
    {

        agent.SetDestination(desiredPosition);
        transform.LookAt(desiredPosition);
        agent.velocity = agent.desiredVelocity;
    }

    public void stareAt(Vector3 target)
    {
        transform.LookAt(target);
    }

    private void createClickAnimation(RaycastHit hit, GameObject moveGroundAnimation)
    {
         Vector3 offset = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);
         Instantiate(moveGroundAnimation, offset, Quaternion.identity);
    }

    
}
