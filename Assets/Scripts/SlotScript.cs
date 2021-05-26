using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour,IDropHandler
{
  public Name sname;
    public bool isFilled;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            isFilled = true;

        }
        else {
            isFilled = false;

        }
        var temp = eventData.pointerDrag;
        var animalenum = temp.GetComponent<OptionScript>().Aname;
        
        if (sname == animalenum || sname == Name.None)
        {
            temp.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position;
            if (sname == animalenum) { temp.GetComponent<OptionScript>().OnSlotDrop(false);
                temp.GetComponent<OptionScript>().inHolder = false;
                temp.GetComponent<DragAndDrop>().droppedOnSlot = true;
                temp.transform.SetParent(gameObject.transform);
            }
            else if(isFilled==false){ temp.GetComponent<OptionScript>().OnSlotDrop(true);
                temp.GetComponent<OptionScript>().inHolder = true;
                temp.GetComponent<DragAndDrop>().droppedOnSlot = true;
                temp.transform.SetParent(gameObject.transform);
            }
            
            
           
        }
        else { temp.GetComponent<DragAndDrop>().droppedOnSlot = false; }
        
    }
    public void InititailizeOptionHolder(Name sname)
    {
        this.sname = sname;
        
    }

}
