using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : CanvasAbstract, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] protected Image[] images;
    public Transform realParent;

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
        //Debug.Log("Begin Drag");
        realParent = this.transform.parent;
        this.transform.SetParent(canvasController.transform);
        SetRaycastTarget(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End Drag");
        transform.SetParent(realParent);
        SetRaycastTarget(true);
    }

    // Set value boolen raycast for images
    public virtual void SetRaycastTarget(bool getValueImage)
    {
        foreach (Image image in images)
        {
            image.raycastTarget = getValueImage;
        }
    }

    //protected override void OnEnable()
    //{
    //    base.OnEnable();
    //    //Debug.Log("On enable chicken");
    //}

    // Set new parent after drag and drop object
    public virtual void SetRealParent(Transform setRealParent)
    {
        realParent = setRealParent;
    }
}