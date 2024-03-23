using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : CanvasAbstract, IDropHandler
{
    [SerializeField] protected string chickenLevelHighest = "Chicken40";

    public void OnDrop(PointerEventData eventData)
    {
        // Get information Drag Item
        GameObject dropObj = eventData.pointerDrag;
        DragItem dragItem = dropObj.GetComponent<DragItem>();

        if (CheckSlotHaveEmpty())
        {
            // Slot Empty
            dragItem.SetRealParent(this.transform);
            return;
        }

        // Check Update Level?
        if (UpdateLevelChicken(dropObj))
        {
            if (CheckChickenIsHighestLv(dropObj) == true) return;
            
            // SFX
            canvasController.AudioManager.PlaySFX(canvasController.AudioManager.effectUpgradeChicken);
            
            // Spawn new chicken (higher level)
            SpawnNewChicken(dropObj.transform);
            // Delete 2 chicken same name
            DeleteChicken(dropObj.transform, dragItem);
            return;
        }

        // Swap 2 chicken with each
        SwapChickens(dragItem);
    }
    
    // Check Object have children?
    protected virtual bool CheckSlotHaveEmpty()
    {
        if (transform.childCount == 0) return true;
        return false;
    }

    // Check name of Drag Item with children Item Slot have same name?
    protected virtual bool UpdateLevelChicken(GameObject dropItem)
    {
        GameObject itemChildren = gameObject.GetComponentInChildren<DragItem>().gameObject;
        if (dropItem.name == itemChildren.name) return true;
        return false;
    }

    protected bool CheckChickenIsHighestLv(GameObject prefab)
    {
        // Check chicken is the chicken level max
        if (prefab.name == chickenLevelHighest)
        {
            Debug.Log("The Chicken is highest level");
            return true;
        }
        return false;
    }

    // Delete 2 chicken same name
    protected virtual void DeleteChicken(Transform chickenDrop, DragItem dragItem)
    {
        Transform chickenChildren = transform.GetComponentInChildren<DragItem>().transform;
        canvasController.ChickenSpawner.Despawn(chickenChildren);
        //dragItem.SetRaycastTarget(true);
        canvasController.ChickenSpawner.Despawn(chickenDrop);
    }

    // Spawn chicken have lv higher
    protected virtual void SpawnNewChicken(Transform prefab)
    {
        canvasController.SpawnChicken.SpawnChickenHighLevel(prefab, this.transform);
    }

    protected virtual void SwapChickens(DragItem dragItem)
    {
        // Save transForm before change
        Transform storeTransform = dragItem.realParent;
        // Change children object
        this.transform.GetComponentInChildren<DragItem>().transform.SetParent(storeTransform);
        dragItem.SetRealParent(this.transform);
    }
}