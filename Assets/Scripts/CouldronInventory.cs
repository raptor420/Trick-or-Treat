using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CouldronInventory : MonoBehaviour {
    [SerializeField] // we put the items here
    Equipmanager equipmanager;
    [SerializeField]
    CouldronUI[] couldronUI;
    [SerializeField]
    Recipes[] recipes;

    [SerializeField]
   public  Items[] item;
    public CouldronInventory couldron;
    [SerializeField]
    public Items Result;
  public  GameManager manager;
    public event Action Recieved;
    //public event Action ItemGotinCouldron;// scorenow, after score deactivate
    void Start () {
        Recieved += manager.Score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  public  void AddToCouldron(Items additem)
    { if (CheckCouldronHasSpace())
        {
            for (int i = 0; i < item.Length ; i++)
            {
                if (item[i] == null)
                {
                    item[i] = additem;
                    couldronUI[i].SetImage(additem.Icon);
                    equipmanager.DiscardAndDestroy();

                    break;

                }

            }

        }
        else Debug.Log("vora");


    }
   public  bool CheckCouldronHasSpace()
    {
        for(int i = 0; i < item.Length; i++)
        {
            if(item[i] == null)
            {
                return true;

            }

        }


        return false;
    }


    public void magic()
    {

        if (!CheckCouldronHasSpace())
        {


            foreach (Recipes rec in recipes)
           
                rec.Craft(this);

            
                

        }
    }
    public void EmptyInventoryItems()
    {
        for (int i = 0; i < item.Length; i++)
        {
            couldronUI[i].SetImage(null);

            item[i] = null;

        }

    }

  public  void EmptyResult()
    {
        
            Result = null;
    }
    public int itemAmount(Items searchItem)
    {
        int n = 0;
        for(int i= 0; i < item.Length;i++)
        {
            if(item[i]==searchItem)
            {
                n++;
            }
        }
        //Debug.Log("item amount " + n);

        return n;
    }
}
