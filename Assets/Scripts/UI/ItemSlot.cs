using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : ErshenMonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropObj = eventData.pointerDrag;
        DragItem dragItem = dropObj.GetComponent<DragItem>();
        if (CheckChildrenHaveSlot() == true)
        {
            dragItem.SetRealParent(this.transform);
        }
        else
        {
            // Save transForm before change
            Transform storeTransform = dragItem.realParent;
            // Change children object
            this.transform.GetComponentInChildren<DragItem>().transform.SetParent(storeTransform);
            dragItem.SetRealParent(this.transform);
        }
    }
    
    // Check Object children have emty?
    protected virtual bool CheckChildrenHaveSlot()
    {
        DragItem dragItem = transform.GetComponentInChildren<DragItem>();
        if (dragItem == null) return true;
        return false;
    }
}
