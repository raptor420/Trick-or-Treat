using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couldron : Interactable {



    [SerializeField]
    CouldronInventory couldronInv;
    [SerializeField]
    Equipmanager equipmanager;
    public override void Interact()
    {
        base.Interact();

        DoMagic();

    }

    public void DoMagic()
    { 
        couldronInv.AddToCouldron(equipmanager.Items);
        couldronInv.magic();

        Debug.Log("Added to couldron");
        // make a storage for couldron that stores two items, once filled with two items we make something

    }
}
