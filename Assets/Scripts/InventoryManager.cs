using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour {
    [SerializeField] Invnetory inventory;
    [SerializeField]
    EquipmentPanel EquipmentPanel;
    public void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        EquipmentPanel.OnItemRightClicked += UnequipfromSlot;
    }
    private void EquipFromInventory(Items item)
    {
        if(item is EquippableItem)
        {

            Equip((EquippableItem)item);
        }

    }

    public void UnequipfromSlot(Items item)
    {
        if(item is EquippableItem)
        {
            UnEquip((EquippableItem)item);

        }

    }
    public void Equip(EquippableItem item)
    {


        if (inventory.RemoveItem(item))
        {
            EquippableItem prevItem;
            if (EquipmentPanel.AddItem(item,out prevItem))
            {

                if (prevItem != null)
                {
                    inventory.Additem(prevItem);

                }
               
            }

            else
            {
                inventory.Additem(item);
            }

        }

    }
    public void UnEquip(EquippableItem item)
    {
        if(!inventory.IsFull() && EquipmentPanel.RemoveItem(item))
        {


            inventory.Additem(item);
        }


    }
	
}
