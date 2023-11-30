using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : ErshenMonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    
    // The score game have 2 object image
    [SerializeField] protected Image[] images;
    [SerializeField] protected Transform realParent;

    // Set new parent after drag and drop object
    public virtual void SetRealParent(Transform setRealParent)
    {
        realParent = setRealParent;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadImages();
    }

    protected virtual void LoadImages()
    {
        if (images == null) return;
        images = transform.GetComponentsInChildren<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        realParent = this.transform.parent;
        this.transform.SetParent(ButtonManager.Instance.transform);
        
        // Turn off raycast for images
        foreach (Image image in images)
        {
            image.raycastTarget = false;
        } 
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(realParent);

        // Turn off raycast for images -> if not, can't remove
        foreach (Image image in images)
        {
            image.raycastTarget = true;
        }
    }
}
