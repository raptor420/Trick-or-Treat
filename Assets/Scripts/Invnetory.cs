using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Invnetory : MonoBehaviour,IItemContainer {

    [SerializeField] List<Items> items;
    [SerializeField] Transform itemsParent;
    [SerializeField]
    ItemSlots[] ItemSlots;
    public event Action<Items> OnItemRightClickedEvent;

    private void Start()
    {
        for (int i = 0; i < ItemSlots.Length; i++)
        {

            ItemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }

    }

    public void OnValidate()
    {
        if (itemsParent != null)
        {
            ItemSlots = itemsParent.GetComponentsInChildren<ItemSlots>();

        }

        RefreshUI();
    }
    private void RefreshUI()
    {

        int i = 0;
        for (; i < items.Count && i < ItemSlots.Length; i++)
        {
            ItemSlots[i].Items = items[i];
        }
        for (; i < ItemSlots.Length; i++)
        {
            ItemSlots[i].Items = null;
        }
    }
    //public void Start()
    //{

    //    for(int i=0; i < ItemSlots.Length; i++)
    //    {


    //        ItemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
    //    }

    //}
    public bool Additem(Items Item)
    {
        if (IsFull())
        {
            return false;

        }

        else
        {

            items.Add(Item);
            RefreshUI();
            return true;
        }
    }


        public bool IsFull()
    {
        return items.Count >= ItemSlots.Length;

    }

    public bool RemoveItem(Items item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            
            return true;
        }

       
            return false;

        }

    public bool ContainsItem(Items item)
    {
        for (int i =0;i<ItemSlots.Length; i++)
        {

            if (ItemSlots[i].Items == item)
            {

                return true;
            }
        }
        return false;
    }

    public int itemcount(Items item)
    {
        int number = 0;
        for (int i = 0; i < ItemSlots.Length; i++)
        {

            if (ItemSlots[i].Items == item)
            {

                number++;
            }
        }
        return number;
    }
}
    
 

    

