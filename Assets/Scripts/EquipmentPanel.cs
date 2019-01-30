using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentPanel : MonoBehaviour
{

    [SerializeField]
    Transform EquipmentSlotsParent;
    [SerializeField]
    EquipmentSlot[] equipmentslots;
    public event Action<Items> OnItemRightClicked;


    private void Start()
    {
        for (int i = 0; i < equipmentslots.Length; i++)
        {

            equipmentslots[i].OnRightClickEvent += OnItemRightClicked;
        }

    }
    private void OnValidate()
    {
        equipmentslots = EquipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();


    }


    public bool AddItem(EquippableItem Item, out EquippableItem prevItem)
    {
        for (int i = 0; i < equipmentslots.Length; i++)
        {
            if (equipmentslots[i].EquipmentType == Item.EquipmentType)
            {
                prevItem = (EquippableItem)equipmentslots[i].Items;
                equipmentslots[i].Items = Item;

                return true;
            }

        }
        prevItem = null;
        return false;

    }

    public bool RemoveItem(EquippableItem Item)
    {
        for (int i = 0; i < equipmentslots.Length; i++)
        {

            if (equipmentslots[i].Items == Item)
            {
                equipmentslots[i].Items = null;
                return true;
            }
          

        }
        return false;


    }
}



