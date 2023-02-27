using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[Serializable]
public class Stat 
{

    public float BaseValue;

    public virtual float Value { get { 
        if (isDirty || BaseValue != lastBaseValue)
            {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            }
        return _value;
        } 
    }

    protected float lastBaseValue = float.MinValue;
    protected bool isDirty = true;
    protected float _value;

    protected readonly List<StatModifier> statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public Stat()
    {

        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    public Stat (float baseValue) : this ()
    {

        BaseValue= baseValue;
    }

    public virtual void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    public virtual bool RemoveModifier(StatModifier mod)
    {

        if (statModifiers.Remove(mod))
        {
            isDirty = true;
            return true;
        }

        return false;
    }

    public virtual bool RemoveAllModifierFromSource(object source)
    {
        bool didRemove = false;

        for (int i = statModifiers.Count - 1; i >= 0; i--)
        {
            if (statModifiers[i].Source == source)
            {
                isDirty = true;
                didRemove= true;
                statModifiers.RemoveAt(i);
            }
        }

        return didRemove;
    }

    protected virtual float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentageAdd = 0;

        for (int i = 0; i < statModifiers.Count; i++)
        {
            
            StatModifier mod = statModifiers[i];

            switch (mod.Type)
            {
                case StatModifierType.Flat:
                    
                    finalValue += statModifiers[i].Value;
                    break;

                case StatModifierType.percentageAdd:

                    sumPercentageAdd += mod.Value;

                    if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModifierType.percentageAdd)
                    {

                        finalValue *= 1 + sumPercentageAdd;
                    }

                    break;

                case StatModifierType.PercentageMult:

                    finalValue *= 1 + mod.Value;
                    break;

            }

            
        }

        // 12.0001f != 12f
        return (float)Math.Round(finalValue, 4);
    }

    protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
    {

        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0; // if (a.Order == b.Order)
    }

}
