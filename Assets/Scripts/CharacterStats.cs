using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using System;
[Serializable]
public class CharacterStats  {
    public float BaseValue;
    public float Value {


        get
        {

            if (isDirty|| BaseValue != _lastbasevalue)
            {
                _lastbasevalue = BaseValue;

                _value = CalculateFinalValue();
                isDirty = false;
            }

            return _value;


        }


        }

    
    private bool isDirty = true;
    private float _value;
    private float _lastbasevalue =float.MinValue;
    private readonly List <StatModifier> Statmodifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiersPublic;
    public CharacterStats()
    {
        Statmodifiers = new List<StatModifier>();
        StatModifiersPublic = Statmodifiers.AsReadOnly();


    }
   public  CharacterStats(float basevalue) : this()
    {
        BaseValue = basevalue;
        


    }
    public void AddModifier(StatModifier mod)
    {
        isDirty = true;
        Statmodifiers.Add(mod);
        Statmodifiers.Sort(CompareModifierOrder);
    }
    private int CompareModifierOrder(StatModifier a , StatModifier b)
    {
        if(a.Order < b.Order)
        {
            return -1;
        }
        else if (a.Order > b.Order)
        {

            return 1;
        }
        return 0;

    }
    public bool removemodifier(StatModifier mod)
    {


        if (Statmodifiers.Remove(mod))
        {

            isDirty = true;
            return true;
        }
        return false;

    }
    public bool RemoveAllmodifiersfromSource(object source)
    {
        bool didremove = false;
        for (int i = Statmodifiers.Count-1; i >=0 ; i--)
        {
            StatModifier mod = Statmodifiers[i];
            if(mod.Source == source)
            {
                isDirty = true;
                didremove = true;
                Statmodifiers.RemoveAt(i);
            }
        }
        return didremove;
    }
    private float CalculateFinalValue()
    {
        float sumPercentAdd = 0;
        float finalValue = BaseValue;
        for(int i =0; i <Statmodifiers.Count; i++)
        {
            StatModifier mod = Statmodifiers[i];
            if (mod.Type == StatModifier.Statmodtype.Flat)
            {
                finalValue += mod.Value;
            }
            else if(mod.Type == StatModifier.Statmodtype.Percent)
            {

                finalValue *= 1 + mod.Value;
            }
            else if (mod.Type == StatModifier.Statmodtype.PercentAdd)
            {
                sumPercentAdd += mod.Value;
                if((i+1) >= Statmodifiers.Count || Statmodifiers[i+1].Type != StatModifier.Statmodtype.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;

                }

            }

        }
        return (float)Math.Round(finalValue, 4);
    }
}
