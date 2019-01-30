using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu]
public class Recipes : ScriptableObject
{
   // public event Action MadeItem;
    [Serializable]

    public struct ItemAmounts
    {
        public Items Item;
        [Range(1, 2)]
        public int Amount;

    }
    [SerializeField]
    CouldronInventory CouldronInv;

    public List<ItemAmounts> materials;
    public List<ItemAmounts> Results;
    // Use this for initialization
    public bool CanCraft(CouldronInventory couldron)
    {
        //if (couldron.item[couldron.item.Length-1] != null)
        //{
        //    for (int i = 0; i < couldron.item.Length; i++)
        //    {
        //       if( couldron.item[i] == materials[i].Item)
        //        {
        //            Debug.Log(Results[i].Item);
        //            couldron.Result = Results[i].Item;
        //            return true;
        //        }
        //        return false;// actaully return trash
        //    }


        //}
        //return false;

        foreach (ItemAmounts amounts in materials)
        {

            if (couldron.itemAmount(amounts.Item) < amounts.Amount)
            {
                return false;
            }
        }
        return true;


    }
    public void Craft(CouldronInventory couldron)
    {
        if (CanCraft(couldron))
        {

            couldron.Result = Results[0].Item;
            couldron.EmptyInventoryItems();
            couldron.manager.Score();
            // MadeItem += couldron.Recieved;
            //  MadeItem += couldron.Recieved;
            //  MadeItem();
            //return true;
        }
       
        
        }


        //    if (CanCraft(couldron))
        //    { couldron.Result= 
        //        if (MadeItem != null)
        //        {
        //            Debug.Log("reda");
        //            MadeItem += couldron.manager.Score;
        //            //couldron.ItemGotinCouldron += MadeItem;

        //        }
        //        //Debug.Log(Results[0].Item); craft kore disi
        //    }
        //    else
        //    {

        //        Debug.Log("failed"); // we not making till we ready

        //    }
        //}


    }

