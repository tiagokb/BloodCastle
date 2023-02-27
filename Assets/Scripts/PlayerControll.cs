using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControll : MonoBehaviour
{

    public InventoryObject inventory;
    public GameObject moveGroundAnimation;

    private GameObject target;
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }

    private MovementBehaviour movement;
    private Animator animator;
    private PlayerCombat playerCombat;

    private void Awake()
    {
        movement = GetComponent<MovementBehaviour>();
        animator = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCombat>();
    }

    private void Start()
    {
        playerCombat.TargetedEnemy = Target;
    }

    private void Update()
    {

        playerCombat.TargetedEnemy = Target;

        if (playerCombat.IsAlive() && !playerCombat.isInvulnerable)
        {

            movePlayer();
            Targeting();
            MoveAnimation();
        }
        
    }

    private void MoveAnimation()
    {
        animator.SetFloat(AnimatorParams.MOVING, movement.agent.velocity.magnitude);
    }

    public void movePlayer()
    {
        if (Input.GetMouseButton(1))
        {
            movement.PlayerMovement(moveGroundAnimation);
        }
    }

    public void Targeting()
    {
        
        if (Target != null 
            && Target.GetComponent<ITargetable>() != null 
            && Target.GetComponent<ITargetable>().Type == ObjectType.Item)
        {

            if (movement.targeting(Target, 1f))
            {

                PickUpItem();
            }
        } 
    }

    private void PickUpItem()
    {
        var item = target.GetComponent<Item>();
        if (item)
        {

            inventory.AddItem(item.item, 1);
            Destroy(target);
        }
    }
}
