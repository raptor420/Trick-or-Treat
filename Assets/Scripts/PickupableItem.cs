
using UnityEngine;

public class PickupableItem : Interactable {

    public Items item;
    public Equipmanager equipmanager;
    public SpriteRenderer sprite;
        void Start () {
        equipmanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Equipmanager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PickUp()
    {
        Debug.Log("pickedup" + item.ItemName);
        equipmanager.Equip(item);
        equipmanager.EquipObjectinScene(this.gameObject);
        //gameObject.transform.SetParent(equipmanager.player);// these should be handled by equip manager
        //gameObject.SetActive(false);
      
        // needs logic, jodi equip korte parecheck with slot empty checker to decide wether equip or requip
      //  Destroy(this.gameObject);


    }
    public override void Interact()
    {
        //base.Interact();
        PickUp();
    }
    public void OnValidate()
    {
        gameObject.name = item.ItemName;
        if (sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sprite = item.Icon;


        }
        sprite.sprite = item.Icon;

    }
    public void togglehide(bool On)
    {

        gameObject.SetActive(On);
    }
}
