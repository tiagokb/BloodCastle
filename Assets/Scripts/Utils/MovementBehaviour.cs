using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class MovementBehaviour : MonoBehaviour
{

    public NavMeshAgent agent;
    private GameObject player;

    private Vector3 originalPosition;

    private Camera mCamera;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        agent.updateRotation = false;
        originalPosition = agent.transform.position;

        mCamera = Camera.main;
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
    internal void PlayerMovement(GameObject moveGroundAnimation)
    {

        Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {

                if (Vector3.Distance(hit.point, transform.position) < 0.5f)
                {
                    return;
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

                    moveTo(hit.point, 0);
                }
            }
        }
    }

    public void DodgeMovement(float dodgeDistance)
    {

        Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.ResetPath();
                transform.LookAt(hit.point);
                Vector3 newPosition = Vector3.MoveTowards(transform.position, hit.point, dodgeDistance);
                moveTo(newPosition, 0);
            }
        }
    }

    private void cancelAnimation()
    {
        GetComponent<Animator>().Rebind();
    }

    public bool targeting(GameObject target, float stoppingDistance)
    {

        bool isCloseEnough = false;

        if (Vector3.Distance(transform.position, target.transform.position) > stoppingDistance)
        {

            moveTo(target.transform.position, stoppingDistance);
            isCloseEnough = false;
        }
        else
        {
            agent.ResetPath();
            transform.LookAt(target.transform.position);
            agent.velocity = Vector3.zero;
            isCloseEnough = true;
        }

        return isCloseEnough;
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

    internal void Stop()
    {
        agent.ResetPath();
        agent.velocity = Vector3.zero;
        cancelAnimation();
    }
}
