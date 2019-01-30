using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EquipmentType
{

    Hat,
    Costume,
    Accessory,


}
[CreateAssetMenu]
public class EquippableItem : Items {

    public int HappinessBonus;
    public int SpookyBonus;
    [Space]
    public EquipmentType EquipmentType;
}
