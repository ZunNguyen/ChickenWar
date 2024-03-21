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

        if (CheckSlotHaveEmpty() == true)
        {
            dragItem.SetRealParent(this.transform);
            return;
        }
        else
        {
            // Check Update Level
            if (UpdateLevelChicken(dropObj))
            {
                if (CheckChickenIsHighestLevel(dropObj) == true) return;

                // Audio
                canvasController.AudioManager.PlaySFX(canvasController.AudioManager.effectUpgradeChicken);

                // Spawn new chicken (higher level)
                SpawnChicken(dropObj.transform);
                // Delete 2 chicken same name
                DeleteChicken(dropObj.transform);
                return;
            }
            else
                // Swap 2 chicken with each
                SwapChickens(dragItem);
        }
    }
    
    // Check Object children have emty?
    protected virtual bool CheckSlotHaveEmpty()
    {
        //DragItem dragItem = transform.GetComponentInChildren<DragItem>();
        //if (dragItem == null) return true;
        if (transform.childCount == 0) return true;
        return false;
    }

    // Check name of Drag Item with children Item Slot
    protected virtual bool UpdateLevelChicken(GameObject dropItem)
    {
        GameObject itemChildren = gameObject.GetComponentInChildren<DragItem>().gameObject;
        if (dropItem.name == itemChildren.name) return true;
        return false;
    }

    // Delete 2 chicken same name
    protected virtual void DeleteChicken(Transform chickenDrop)
    {
        Transform chickenChildren = transform.GetComponentInChildren<DragItem>().transform;
        canvasController.ChickenSpawner.Despawn(chickenChildren);
        DragItem dragItem = chickenDrop.GetComponent<DragItem>();
        dragItem.SetRaycastTarget(true);
        canvasController.ChickenSpawner.Despawn(chickenDrop);
    }

    protected virtual void SpawnChicken(Transform prefab)
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

    protected bool CheckChickenIsHighestLevel(GameObject prefab)
    {
        if (prefab.name == chickenLevelHighest)
        {
            Debug.Log("The Chicken is highest level");
            return true;
        }
        return false;
    }
}