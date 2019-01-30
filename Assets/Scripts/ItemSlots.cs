using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlots : MonoBehaviour,IPointerClickHandler {
    public event Action<Items> OnRightClickEvent;

    [SerializeField]
    private Image _Image;
    private Items _Items;
public Items Items  {

        get
        {
            return _Items;
        }
        set
        {
            _Items = value;
            if(_Items == null)
            {
                _Image.enabled = false;
            }
            else   {
                _Image.sprite = _Items.Icon;
                _Image.enabled = true;
            }


        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData!=null && eventData.button == PointerEventData.InputButton.Right)
        {
            if(Items!= null && OnRightClickEvent != null)
            {
                OnRightClickEvent(Items);

            }

        }
    }

    protected virtual void OnValidate()
    {
        if(_Image== null)
        {
            _Image = GetComponent<Image>();
        }

    }

}


