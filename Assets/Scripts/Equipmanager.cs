using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipmanager : MonoBehaviour {
    [SerializeField]
    GameObject Equippedobject;
    [SerializeField]

    Items equippedItem;
    public EquipSLot equipslot;
    [SerializeField]
    SpriteRenderer holder;
    [SerializeField]

   public Transform player;
    [SerializeField]
    GameObject PutItem;
    [SerializeField]
    UIMANAGER ui;
    public Items Items
    {
        get {

            return equippedItem; 
        }
        set
        {
            equippedItem = value;
        }
    }
    public void Equip(Items item)
    {
        if(equippedItem == null && SlotEmptyChecker())
        {
            equippedItem = item;
            equipslot.Items = equippedItem;
            holder.sprite = item.Icon;
            
            //wecan instantaniate sometihing with the item param

        }
        else
        {

            if (Discard())
            { //discard and requip
                Debug.Log("shor beta");
                //what to wit already equipped item
                equippedItem = item;
                equipslot.Items = equippedItem;
                holder.sprite = item.Icon;
            }


        }

    }
    // Use this for initialization
    void OnValidate()
    {
        equipslot.Items = null;

    }

    public bool SlotEmptyChecker()
    {
        if(equipslot.Items == null)
        {
            return true;

        }
        return false;

    }

    public bool Discard() {
        if (!SlotEmptyChecker()) // checking if slot empty
        { // if check keda call kore couldron naki itemslots
            PutEquippedObjectInScene(Equippedobject);
            //remove the item need to add placement in the world
            equippedItem = null;
            equipslot.Items = null;
            holder.sprite = null;
            return true;
        }
        return false;
    }
    public bool DiscardAndDestroy()
    {
        if (!SlotEmptyChecker()) // checking if slot empty
        { // if check keda call kore couldron naki itemslots
            //PutEquippedObjectInScene(Equippedobject);
            //remove the item need to add placement in the world
            equippedItem = null;
            equipslot.Items = null;
            holder.sprite = null;
            return true;
        }
        return false;
    }

    public void EquipObjectinScene(GameObject myobject)
    {
        Equippedobject = myobject;
        myobject.transform.SetParent(player);// these should be handled by equip manager
        myobject.SetActive(false);

    }
    public void PutEquippedObjectInScene(GameObject myobject)
    {
        myobject.transform.parent = null;
        //setit in the world again
        myobject.SetActive(true);
    }

    // Update is called once per frame
    
}
