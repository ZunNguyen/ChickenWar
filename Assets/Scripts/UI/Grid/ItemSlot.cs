using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : ErshenMonoBehaviour, IDropHandler
{
    [SerializeField] protected CanvasController canvasController;
    [SerializeField] protected string chickenLevelHighest = "Chicken40";

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCanvasController();
    }

    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = transform.GetComponentInParent<CanvasController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Get information Drag Item
        GameObject dropObj = eventData.pointerDrag;
        DragItem dragItem = dropObj.GetComponent<DragItem>();

        if (CheckChildrenHaveSlot() == true)
        {
            dragItem.SetRealParent(this.transform);
            return;
        }
        else
        {
            // Check Update Level
            if (UpdateLevelChicken(dropObj))
            {
                if (CheckChickenIsHighestLevel(dropObj.transform) == true) return;
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
    protected virtual bool CheckChildrenHaveSlot()
    {
        DragItem dragItem = transform.GetComponentInChildren<DragItem>();
        if (dragItem == null) return true;
        return false;
    }

    // Check name of Drag Item with children Item Slot
    protected virtual bool UpdateLevelChicken(GameObject dropItem)
    {
        GameObject itemChildren = gameObject.GetComponentInChildren<DragItem>().gameObject;
        if (dropItem.gameObject.name == itemChildren.name) return true;
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

    protected bool CheckChickenIsHighestLevel(Transform prefab)
    {
        if (prefab.gameObject.name == chickenLevelHighest)
        {
            Debug.Log("The Chicken is highest level");
            return true;
        }
        return false;
    }
}