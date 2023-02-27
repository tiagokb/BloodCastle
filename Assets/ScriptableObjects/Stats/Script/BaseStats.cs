using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Base Stats", menuName = "Stats System/Base Stats")]
public class BaseStats : ScriptableObject
{

    public Dictionary<StatsNames, Stat> Stats = new Dictionary<StatsNames, Stat>();

    [SerializeField]
    private List<StatModel> statModels= new List<StatModel>();

    public void Initialize()
    {

        foreach (var s in statModels)
        {
            Stats.Add(s.Name, s.Stat);
        }
    }

    public float GetStatValue(StatsNames name)
    {

        if (Stats.TryGetValue(name, out var stat))
        {
            return stat.Value;
        }
        {
            Debug.Log($"No stat value found for {name} on {this.name}");
            return 0f;
        }
       
    }

    public float GetMaxLife()
    {
        float vitality = GetStatValue(StatsNames.Vitality);
        return vitality * 5;
    }
}


[Serializable]
public class StatModel
{
    public StatsNames Name;
    public Stat Stat;
}

