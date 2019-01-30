using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier : MonoBehaviour {
    public enum Statmodtype{

      Flat =100,
        Percent = 200,
        PercentAdd = 300,


    }
    public readonly float Value;
    public readonly Statmodtype Type;
    public readonly int Order;
    public readonly object Source;
    public StatModifier(float value, Statmodtype type, int order, object source)
    {
        Value = value;
        Type = type;
        Order = order;
        Source = source;
    }
    public StatModifier(float value, Statmodtype type) : this (value,type, (int)type,null)
    {

    }
    public StatModifier(float value, Statmodtype type,int order) : this(value, type, order, null)
    {

    }
    public StatModifier(float value, Statmodtype type,object source) : this(value, type, (int)type, source)
    {

    }
}
