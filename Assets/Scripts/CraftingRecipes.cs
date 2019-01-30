using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu]

public class CraftingRecipes : ScriptableObject
{

    [Serializable]
    public struct ItemAmounts
    {
        public Items Item;
        [Range(1, 99)]
        public int Amount;

    }
    public List<ItemAmounts> materials;
    public List<ItemAmounts> Resuls;


    public bool CanCraft(IItemContainer itemcontainer)


    {

        foreach (ItemAmounts itemamounts in materials)
        {

            if (itemcontainer.itemcount(itemamounts.Item) < itemamounts.Amount)
            {
                return false;
            }

        }
        return true;
    }
    public void Craft(IItemContainer itemcontainer)
    {
        if (CanCraft(itemcontainer))
        {
            foreach (ItemAmounts itemamount in materials)
            {
                for (int i = 0; i < itemamount.Amount; i++)
                {
                    itemcontainer.RemoveItem(itemamount.Item);
                }

            }

            foreach (ItemAmounts itemamount in Resuls)
            {
                for (int i = 0; i < itemamount.Amount; i++)
                {
                    itemcontainer.Additem(itemamount.Item);
                }



            }
        }
    }
}
