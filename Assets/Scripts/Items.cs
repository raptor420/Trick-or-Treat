using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu]
public class Items : ScriptableObject {
    [Serializable]
    public enum Type
    {
Trick ,
Treat



    }

  public  int typelength = Enum.GetNames(typeof(Type)).Length;
    public string ItemName;
    public Sprite Icon;
    public Type type;
  




}
