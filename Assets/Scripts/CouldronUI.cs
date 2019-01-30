using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CouldronUI : MonoBehaviour {
    Image image;
    [SerializeField]
    Items item;
	// Use this for initialization

  
	public void SetImage (Sprite sprite) {
        if (sprite == null)
        {
            //image = GetComponent<Image>();
           // image.sprite = null;
            image.enabled = false;
        }
        else
        {
            image.sprite = sprite;
            image.enabled = true;

        }
	}
    public void emptyImage()
    {
        

    }
	
	// Update is called once per frame
	
    void UpdateImage(){

        }
  public  void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
            image.enabled = false;
        }
      
        
    }
}
