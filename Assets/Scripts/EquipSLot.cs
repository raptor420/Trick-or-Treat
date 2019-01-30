using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipSLot : MonoBehaviour {
    [SerializeField]

    Items EquippedItem;
    Image image;
    public Items Items
    {
        get
        {
            return EquippedItem;

        }
        set
        {
            EquippedItem = value;
            if(EquippedItem == null )
            {
                image.enabled = false;

            }
            else
            {
                image.sprite = Items.Icon;
                image.enabled = true;


            }



        }

    }
 
    
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }

    }

  
}
