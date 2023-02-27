using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Stats : MonoBehaviour, IStats
{

    public BaseStats BaseStats;

    public float MaxHealth => BaseStats.GetMaxLife();
    private float _health;
    public float Health
    {
        get => _health;
        private set => _health = value;
    }

    private void Awake()
    {
        BaseStats.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    public float GetStatValue(StatsNames name)
    {
        return BaseStats.GetStatValue(name);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
