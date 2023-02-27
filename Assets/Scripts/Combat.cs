using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public interface IStats
{
    float Health { get; }
    float GetStatValue(StatsNames statName);
    void TakeDamage(float damage);
}

public class Combat : MonoBehaviour
{

    public AttackTypes heroAttackType;

   

    [field: NonSerialized]
    public IStats stats;

    [field: NonSerialized]
    public ITargetable targetable;

    public GameObject targetedEnemy;
    public GameObject TargetedEnemy
    {
        get { return targetedEnemy; }
        set { targetedEnemy = value; }
    }

    public IStats Stats
    {
        get { return stats; }
    }

    public float vanishTimer;

    public bool isInvulnerable = false;

    protected MovementBehaviour movementBehaviour;
    protected Animator animator;
    protected bool isNotDead = true;

    private void Awake()
    {
        movementBehaviour = GetComponent<MovementBehaviour>();
        animator = GetComponent<Animator>();
        targetable = (ITargetable)GetComponent<Targetable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        stats = (IStats)GetComponent<Stats>();

        if (targetable != null && targetable.Type == ObjectType.Object)
        {
            vanishTimer = GameConfig.objectVanishTimer;
        }
        else
        {
            vanishTimer = GameConfig.corpseVanishTimer;
        }

        Init();
    }

    void Update()
    {
        if (!IsAlive() && isNotDead)
        {
           Die();
        }

        Targeting();
        OnUpdate();
    }

    public bool IsAlive()
    {
        return stats.Health > 0;
    }

    public virtual void TakeDamage(float damage, GameObject striker = null)
    {

        if (isInvulnerable)
        {
            return;
        }

        stats.TakeDamage(damage);
    }

    public void Attack()
    {

        if (targetedEnemy != null)
        {

            if (targetedEnemy.GetComponent<Targetable>() != null)
            {

                targetedEnemy.GetComponent<Combat>().TakeDamage(stats.GetStatValue (StatsNames.Strength), gameObject);
            }
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject, vanishTimer);
    }

    protected virtual void Init()
    {
        //override if need "Start" on inherited class
    }

    protected virtual void OnUpdate()
    {
        //override if need "Upgrade" on inherited class
    }

    protected virtual void Targeting()
    {
        // override to targeting targets
    }
}
