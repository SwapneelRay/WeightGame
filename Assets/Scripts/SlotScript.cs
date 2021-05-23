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
        print(animalenum);
        print(name);
        if (sname == animalenum || sname == Name.None)
        {
            temp.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position;
            temp.GetComponent<OptionScript>().OnSlotDrop();
            temp.GetComponent<DragAndDrop>().droppedOnSlot = true;
        }
        else { temp.GetComponent<DragAndDrop>().droppedOnSlot = false; }

    }
    public void InititailizeOptionHolder(Name sname)
    {
        this.sname = sname;
        
    }

}
