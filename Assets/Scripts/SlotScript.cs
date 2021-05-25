using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour,IDropHandler
{
  public Name sname;

    public void OnDrop(PointerEventData eventData)
    {
        var temp = eventData.pointerDrag;
        var animalenum = temp.GetComponent<OptionScript>().Aname;
        
        if (sname == animalenum || sname == Name.None)
        {
            temp.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position;
            if (sname == animalenum) { temp.GetComponent<OptionScript>().OnSlotDrop(false);
                temp.GetComponent<OptionScript>().inHolder = false;
            }
            else { temp.GetComponent<OptionScript>().OnSlotDrop(true);
                temp.GetComponent<OptionScript>().inHolder = true;
            }
            
            temp.GetComponent<DragAndDrop>().droppedOnSlot = true;
            temp.transform.SetParent(gameObject.transform);
           
        }
        else { temp.GetComponent<DragAndDrop>().droppedOnSlot = false; }
        temp.transform.rotation = Quaternion.identity;
    }
    public void InititailizeOptionHolder(Name sname)
    {
        this.sname = sname;
        
    }

}
